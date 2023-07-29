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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyDesktopApp2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuizPage : Page
    {
        public QuizPage()
        {
            this.InitializeComponent();
        }
        private int correctAnswers = 0;

        private void OnSubmitQuizClicked(object sender, RoutedEventArgs e)
        {
            // Check each question's selected option and count correct answers
            if (rbQ1Option1.IsChecked == true)
                correctAnswers++;

            if (rbQ2Option2.IsChecked == true)
                correctAnswers++;

            if (rbQ3Option3.IsChecked == true)
                correctAnswers++;

            if (rbQ4Option4.IsChecked == true)
                correctAnswers++;

            // Calculate the quiz score and show it to the user
            double score = (correctAnswers / 4.0) * 100; // Assuming 4 questions
            string resultMessage = $"Quiz Score: {score}% ({correctAnswers} out of 4 correct)";
            ShowQuizResult(resultMessage);
        }

        private void ShowQuizResult(string message)
        {
            // Hide the quiz panel and show the result to the user
            quizPanel.Visibility = Visibility.Collapsed;
            resTextBlock.Text = message;
            resultTextBlock.Visibility = Visibility.Visible;
        }

        private void ReturnToReg(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Check if the navigation parameter is of type Person
            if (e.Parameter is StudentDetails person)
            {
                // Access the data from the person object
                string name = person.Name;
                string dept = person.Department;

                // Now you can use the data as needed in the destination frame
                // For example, display the name and age in text blocks
                NameTextBlock.Text = name;
                DeptTextBlock.Text = dept;
            }
        }


    }
}
