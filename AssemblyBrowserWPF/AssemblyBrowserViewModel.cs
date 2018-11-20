using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace AssemblyBrowserWPF
{
    public class AssemblyBrowserViewModel : INotifyPropertyChanged
    {
        private string filename;
        private AssemblyBrowser.AssemblyInfo result;
        public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand openFileCommand;

        public string Filename
        {
            get
            {
                return Path.GetFileName(filename);
            }
            set
            {
                filename = value;
                OnPropertyChanged(nameof(Filename));
            }
        }

        public AssemblyBrowser.AssemblyInfo Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public DelegateCommand OpenFileCommand
        {
            get
            {
                return openFileCommand ?? (openFileCommand = new DelegateCommand(OpenFile));
            }
        }

        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void OpenFile(object obj)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Library Files (*.dll)|*.dll";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Filename = openFileDialog.FileName;
                    Result = new AssemblyBrowser.AssemblyBrowser().Browse(openFileDialog.FileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
