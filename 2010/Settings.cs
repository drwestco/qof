﻿namespace QuickOpenFile
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [CLSCompliant(false), ComVisible(true)]
    public class Settings : DialogPage
    {
        [Category("Search")]
        [DisplayName("Treat space as wildcard (*)")]
        [Description(@"Allows you to match ""SearchEngine.cs"" by typing ""se en"". If unchecked, a space will only match an explicit space in the filename.")]
        public bool SpaceAsWildcard { get; set; }

        [Category("Search")]
        [DisplayName("Search anywhere")]
        [Description(@"Search for the expression anywhere in the filename. If unchecked, only file names that start with the search expression will be shown.")]
        public bool SearchInTheMiddle { get; set; }

        [Category("Search")]
        [DisplayName("Allow CamelCase pattern search")]
        [Description(@"Allows you to match SearchEngine.cs by typing ""SeEn"" or ""SE"".")]
        public bool UseCamelCase { get; set; }

        [Category("Search")]
        [DisplayName("Ignore external dependencies")]
        [Description(@"Ignore files listed by Intellisense in External Dependencies folders.")]
        public bool IgnoreExternalDependencies { get; set; }

        [Category("Search")]
        [DisplayName("Ignore patterns")]
        [Description(@"If a file name matches one of these patterns, it will not be included in the result list. All search options (eg. camel case) apply also to this negative match.")]
        public string[] IgnorePatterns { get; set; }

        [Category("Display")]
        [DisplayName("Maximum results")]
        [Description(@"Limit search results that are displayed. Increases performance when searching in large solutions.")]
        public int ResultsLimit { get; set; }

        [Category("Display")]
        [DisplayName("Open multiple files")]
        [Description(@"Allow opening multiple files from a single search. Displays checkboxes next to each result. Hit space to select, and enter to open them all.")]
        public bool OpenMultipleFiles { get; set; }

        [Category("Display")]
        [DisplayName("Auto resize columns")]
        [Description(@"Automatically resize columns to fit the search results.")]
        public bool AutoColumnResize { get; set; }

        public Settings()
        {
            SpaceAsWildcard = true;
            SearchInTheMiddle = true;
            UseCamelCase = true;
            IgnoreExternalDependencies = false;
            IgnorePatterns = new string[0];
            ResultsLimit = 50;
            OpenMultipleFiles = false;
            AutoColumnResize = true;
        }
    }
}