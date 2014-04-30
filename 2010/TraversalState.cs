using System;
using System.Collections.Generic;
using System.IO;

namespace QuickOpenFile
{
    public class TraversalState
    {
        public string CurrentSolutionName { get; set; }

        private string _currentSolutionDir;
        private Uri _currentSolutionUri;

        public string CurrentSolutionDir
        {
            get { return _currentSolutionDir; }
            set
            {
                _currentSolutionDir = value;
                if (string.IsNullOrEmpty(_currentSolutionDir))
                {
                    _currentSolutionUri = null;
                }
                else
                {
                    if (!_currentSolutionDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        _currentSolutionDir += Path.DirectorySeparatorChar;
                    }

                    _currentSolutionUri = new Uri(_currentSolutionDir);
                }
            }
        }

        public Uri CurrentSolutionUri { get { return _currentSolutionUri; } }

        public string CurrentProjectName { get; set; }

        public TraversalState()
        {
            Clear();
        }

        public void Clear()
        {
            CurrentSolutionName = "";
            CurrentSolutionDir = "";
            CurrentProjectName = "";
        }

        public string SolutionRelativePath(string filePath)
        {
            if (_currentSolutionUri == null)
            {
                return filePath;
            }

            Uri fileUri = new Uri(filePath);

            return Uri.UnescapeDataString(_currentSolutionUri.MakeRelativeUri(fileUri).ToString()).Replace('/', Path.DirectorySeparatorChar);
        }
    }
}
