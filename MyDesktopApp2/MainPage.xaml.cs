// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyDesktopApp2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

            private void OnSubmitButtonClicked(object sender, RoutedEventArgs e)
            {

            StudentDetails student = new StudentDetails
            {
                Name = txtName.Text,
                Age = int.Parse(txtAge.Text),
                Department = GetSelectedDepartment()
            };
            StudentDatabaseHelper helper = new StudentDatabaseHelper();
            helper.UpdateDatabase(student);


            this.Frame.Navigate(typeof(QuizPage), student);

                // Do something with the form data, such as saving it to a database or displaying a message.
            }

            private string GetSelectedDepartment()
            {
                if (rbComputerEngineering.IsChecked == true)
                    return "Computer Engineering";
                else if (rbMechatronics.IsChecked == true)
                    return "Mechatronics";
                else if (rbAgriculturalScience.IsChecked == true)
                    return "Agricultural Science";
                else if (rbMaths.IsChecked == true)
                    return "Maths";
                else
                    return string.Empty;
            }
        }
    }

