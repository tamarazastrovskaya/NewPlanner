using System;
using System.ComponentModel;
using System.Windows;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDateList.json";
        private BindingList<TodoModel> _todoDateList;
        private FileIOService _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                _todoDateList = _fileIOService.LoadDate();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }


            dgTodoList.ItemsSource = _todoDateList;
            _todoDateList.ListChanged += _todoDateList_ListChanged;

        }

        private void _todoDateList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {

                try
                {
                    _fileIOService.SaveDate(sender);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    Close();
                }


            }
        }
    }
}
