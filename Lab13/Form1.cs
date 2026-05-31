using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Security.AccessControl;

namespace Lab13
{
    public partial class Form1 : Form
    {
        private string currentPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDrives();
        }

        private void LoadDrives()
        {
            comboBoxDrives.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                comboBoxDrives.Items.Add(drive.Name);
            }

            if (comboBoxDrives.Items.Count > 0)
            {
                comboBoxDrives.SelectedIndex = 0;
            }
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrives.SelectedItem == null) return;

            string driveName = comboBoxDrives.SelectedItem.ToString();
            DriveInfo drive = new DriveInfo(driveName);

            rtbInfoAndContent.Clear();
            rtbInfoAndContent.AppendText($"ВЛАСТИВОСТІ ДИСКА {drive.Name}\n");
            rtbInfoAndContent.AppendText($"Тип диска: {drive.DriveType}\n");

            if (drive.IsReady)
            {
                rtbInfoAndContent.AppendText($"Файлова система: {drive.DriveFormat}\n");
                rtbInfoAndContent.AppendText($"Загальний розмір: {drive.TotalSize / 1024 / 1024 / 1024} ГБ\n");
                rtbInfoAndContent.AppendText($"Вільне місце: {drive.TotalFreeSpace / 1024 / 1024 / 1024} ГБ\n");

                currentPath = drive.RootDirectory.FullName;
                UpdateNavigation();
            }
            else
            {
                rtbInfoAndContent.AppendText("Диск не готовий до використання\n");
            }
        }

        private void UpdateNavigation()
        {
            txtCurrentPath.Text = currentPath;
            pictureBoxPreview.Image = null;

            listBoxFolders.Items.Clear();
            listBoxFiles.Items.Clear();

            if (!Directory.Exists(currentPath)) return;

            string folderFilter = txtFilterFolders.Text.ToLower();
            string fileFilter = txtFilterFiles.Text.ToLower();

            try
            {
                string[] folders = Directory.GetDirectories(currentPath);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    if (string.IsNullOrEmpty(folderFilter) || name.ToLower().Contains(folderFilter))
                    {
                        listBoxFolders.Items.Add(name);
                    }
                }

                string[] files = Directory.GetFiles(currentPath);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    if (string.IsNullOrEmpty(fileFilter) || name.ToLower().Contains(fileFilter))
                    {
                        listBoxFiles.Items.Add(name);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Немає доступу до цієї папки (системне обмеження Windows)", "Доступ обмежено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxFolders.SelectedItem == null) return;

            string selectedFolder = listBoxFolders.SelectedItem.ToString();
            currentPath = Path.Combine(currentPath, selectedFolder);
            UpdateNavigation();
        }

        private void btnGoUp_Click(object sender, EventArgs e)
        {
            DirectoryInfo parentDir = Directory.GetParent(currentPath);
            if (parentDir != null)
            {
                currentPath = parentDir.FullName;
                UpdateNavigation();
            }
        }

        private void listBoxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem == null) return;

            string fullFolderPath = Path.Combine(currentPath, listBoxFolders.SelectedItem.ToString());
            DirectoryInfo dirInfo = new DirectoryInfo(fullFolderPath);

            rtbInfoAndContent.Clear();
            rtbInfoAndContent.AppendText($"ВЛАСТИВОСТІ ПАПКИ: {dirInfo.Name}\n");
            rtbInfoAndContent.AppendText($"Повний шлях: {dirInfo.FullName}\n");
            rtbInfoAndContent.AppendText($"Час створення: {dirInfo.CreationTime}\n");
            rtbInfoAndContent.AppendText($"Остання зміна: {dirInfo.LastWriteTime}\n\n");

            rtbInfoAndContent.AppendText("Атрибути безпеки (права доступу)\n");
            try
            {
                DirectorySecurity security = dirInfo.GetAccessControl();
                AuthorizationRuleCollection rules = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                foreach (FileSystemAccessRule rule in rules)
                {
                    rtbInfoAndContent.AppendText($"Користувач: {rule.IdentityReference}\nТип доступу: {rule.AccessControlType}\nПрава: {rule.FileSystemRights}\n\n");
                }
            }
            catch { rtbInfoAndContent.AppendText("Немає прав на читання атрибутів безпеки\n"); }
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            string fullFilePath = Path.Combine(currentPath, listBoxFiles.SelectedItem.ToString());
            FileInfo fileInfo = new FileInfo(fullFilePath);

            rtbInfoAndContent.Clear();
            pictureBoxPreview.Image = null;

            rtbInfoAndContent.AppendText($"ВЛАСТИВОСТІ ФАЙЛУ: {fileInfo.Name}\n");
            rtbInfoAndContent.AppendText($"Розширення: {fileInfo.Extension}\n");
            rtbInfoAndContent.AppendText($"Розмір: {fileInfo.Length} байт\n");
            rtbInfoAndContent.AppendText($"Час створення: {fileInfo.CreationTime}\n\n");

            rtbInfoAndContent.AppendText("Атрибути безпеки файлу\n");
            try
            {
                FileSecurity security = fileInfo.GetAccessControl();
                AuthorizationRuleCollection rules = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                foreach (FileSystemAccessRule rule in rules)
                {
                    rtbInfoAndContent.AppendText($"Користувач: {rule.IdentityReference} | {rule.AccessControlType} -> {rule.FileSystemRights}\n");
                }
            }
            catch { rtbInfoAndContent.AppendText("Немає прав на читання атрибутів безпеки\n"); }

            string ext = fileInfo.Extension.ToLower();
            if (ext == ".txt" || ext == ".ini" || ext == ".log" || ext == ".json" || ext == ".cs")
            {
                rtbInfoAndContent.AppendText("\nВМІСТ ТЕКСТОВОГО ФАЙЛУ\n");
                string content = File.ReadAllText(fullFilePath);
                rtbInfoAndContent.AppendText(content);
            }

            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif")
            {
                pictureBoxPreview.Image = Image.FromFile(fullFilePath);
            }
        }

        private void txtFilterFolders_TextChanged(object sender, EventArgs e)
        {
            UpdateNavigation();
        }

        private void txtFilterFiles_TextChanged(object sender, EventArgs e)
        {
            UpdateNavigation();
        }
    }
}