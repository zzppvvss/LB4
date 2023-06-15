using System.Text.Json;
using System.ComponentModel;
namespace LB4
{
    public partial class FORMA : Form
    {
        private List<string> BookAuthors = new List<string> {
      "Franz Kafka",
      "Virginia Woolf",
      "Leo Tolstoy",
      "Friedrich Nietzsche",
      "James Joyce"
    };

        private List<string> BookPublishers = new List<string> {
      "Penguin Random House",
      "Hachette Livre",
      "Bonnier",
      "Bertelsmann",
      "HarperCollins",
      "Egmont Group",
      "Editura Polirom",
      "Editura Humanitas Fiction",
      "Editura Rao",
      "Gallimard",
      "Gyldendal",
      "Mondadori",
      "Gruppo Editoriale Mauri Spagnol",
      "Grupo Planeta",
      "Kiepenheuer & Witsch",
      "Rowohlt Verlag",
      "Simon & Schuster"
    };
        //Привязка
        private readonly Random random = new Random();
        private readonly List<Book> books = new List<Book>();
        private BindingList<Book> bindingListBook = new BindingList<Book>();
        private BindingList<string> bindingListAuthors = new BindingList<string>();
        private BindingList<string> bindingListPublishers = new BindingList<string>();
        private string currentAuthor;
        private string currentPublisher;
        private bool sortAscending = false;

        public FORMA()
        {
            InitializeComponent();
        }

        private void FormaLoading(object sender, EventArgs e)
        {
            // Цикл для создания 10 книг с случайными параметрами и добавления их в коллекцию 
            for (int i = 0; i < 10; i++)
            {
                // Генерация случайных параметров для книги
                string title = "Книга " + i;
                string author = BookAuthors[random.Next(BookAuthors.Count)];
                string publisher = BookPublishers[random.Next(BookPublishers.Count)];
                int year = random.Next(1900, 2023);

                // Создание объекта Book с сгенерированными параметрами и добавление его в коллекцию 
                Book book = new Book(title, author, publisher, year);
                books.Add(book);
            }

            bindingListBook = new BindingList<Book>(books);
            dataGridView1.DataSource = bindingListBook;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1[0, i].ReadOnly = false; // Заголовок книги
                dataGridView1[3, i].ReadOnly = false; // Год выпуска
            }

            bindingListAuthors = new BindingList<string>(BookAuthors);
            authorsCombobox.DataSource = bindingListAuthors;

            bindingListPublishers = new BindingList<string>(BookPublishers);
            publishersCombobox.DataSource = bindingListPublishers;
        }

        private void EditBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, была ли нажата ячейка Автор в строке
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(1))
            {
                var dialog = new AuthorDialog(currentAuthor, BookAuthors);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentAuthor = dialog.SelectedAuthor;

                    dataGridView1.Rows[e.RowIndex].Cells["Author"].Value = currentAuthor;
                }
            }

            // Проверяем, была ли нажата ячейка Издательство в строке
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(2))
            {
                var dialog = new PublisherDialog(currentPublisher, BookPublishers);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentPublisher = dialog.SelectedPublisher;

                    dataGridView1.Rows[e.RowIndex].Cells["Publisher"].Value = currentPublisher;
                }
            }
        }

        //Удаление строки
        private void DelOnClick(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли хотя бы одна строка в таблице
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Удаляем книгу из коллекции books по выбранному индексу
                Book bookToRemove = books[selectedIndex];
                books.Remove(bookToRemove);
                bindingListBook.RemoveAt(selectedIndex);
            }
        }
        // Новая строка
        private void NewRow(object sender, EventArgs e)
        {
            // Создание новой книги со случайными параметрами
            string title = "Title";
            string author = BookAuthors[random.Next(BookAuthors.Count)];
            string publisher = BookPublishers[random.Next(BookPublishers.Count)];
            int year = 2023;
            Book newBook = new Book(title, author, publisher, year);

            bindingListBook.Add(newBook);

            dataGridView1.Refresh();
        }

        //Сортировка
       
       //Изм. Таблицы
        private void changeCombobox(string selectedItem, BindingList<string> list, string newValue)
        {
            if (!String.IsNullOrWhiteSpace(selectedItem) && !String.IsNullOrWhiteSpace(newValue))
            {
                // Получаем индекс выбранного элемента в списке
                int index = list.IndexOf(selectedItem);
                if (index != -1)
                {
                    // Если новое значение не найдено в списке, то заменяем выбранный элемент на новое значение
                    if (list.IndexOf(newValue) == -1)
                    {
                        list[index] = newValue;
                    }
                    else
                    {
                        MessageBox.Show("Не удалось изменить элемент! Каждый элемент должен быть уникальным!");
                    }
                }
            }
        }
        //Смена Автора
        private void changeAuthorButton(object sender, EventArgs e)
        {
            if (authorsCombobox.SelectedItem == null)
            {
                MessageBox.Show("Виберіть Автора");
                return;
            }

            string selectedItem = authorsCombobox.SelectedItem.ToString();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Author"].Value != null && row.Cells["Author"].Value.ToString() == selectedItem)
                {
                    row.Cells["Author"].Value = newAuthorName.Text;
                }
            }

            changeCombobox(selectedItem, bindingListAuthors, newAuthorName.Text);
        }

        private void СhangePublishers(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(publishersCombobox.SelectedItem?.ToString()) || string.IsNullOrWhiteSpace(newPublisherName.Text))
            {
                MessageBox.Show("Необходимо выбрать издательство и ввести новое название.");
                return;
            }


            // Проходим по всем книгам в bindingListBook и меняем название издательства на новое, если текущее название соответствует выбранному в publishersCombobox
            bool publisherChanged = false;
            for (int i = bindingListBook.Count - 1; i >= 0; i--)
            {
                if (bindingListBook[i].Publisher == publishersCombobox.SelectedItem.ToString())
                {
                    dataGridView1.Rows[i].Cells["Publisher"].Value = newPublisherName.Text;
                    publisherChanged = true;
                }
            }

            // Если не удалось изменить название издательства ни в одной книге, выводим сообщение об ошибке
            if (!publisherChanged)
            {
                MessageBox.Show($"Издательство \"{publishersCombobox.SelectedItem}\" не найдено в списке книг.");
                return;
            }

            changeCombobox(publishersCombobox.SelectedItem.ToString(), bindingListPublishers, newPublisherName.Text);

        }
        //Добавить Автора Издателя 
        private void addComboboxValue(BindingList<string> list, string value)
        {
            // Проверяем, что добавляемое значение не является пустым или состоит только из пробелов
            if (!String.IsNullOrWhiteSpace(value))
            {
                if (!list.Contains(value))
                {
                    list.Add(value);
                }
            }
        }

        private void addtheAuthor(object sender, EventArgs e)
        {
            addComboboxValue(bindingListAuthors, newAuthorName.Text);
        }

        private void addthePublisher(object sender, EventArgs e)
        {
            addComboboxValue(bindingListPublishers, newPublisherName.Text);
        }

        private void deleteComboboxValue(string selectedItem, BindingList<string> list)
        {
            // Проверяем, что выбранный элемент не является пустым или состоит только из пробелов
            if (!String.IsNullOrWhiteSpace(selectedItem))
            {
                list.Remove(selectedItem);
            }
        }
        //удалить Автора
        private void delete_Author(object sender, EventArgs e)
        {
            string selectedItem = authorsCombobox.SelectedItem.ToString();

            if (bindingListAuthors.Contains(selectedItem))
            {
                // Проходим по всем книгам в bindingListBook и удаляем книгу, если автор соответствует выбранному в authorsCombobox
                for (int i = bindingListBook.Count - 1; i >= 0; i--)
                {
                    if (bindingListBook[i].Author == selectedItem)
                    {
                        bindingListBook.RemoveAt(i);
                    }
                }

                deleteComboboxValue(selectedItem, bindingListAuthors);
            }
            else
            {
                MessageBox.Show("Выбранный элемент не найден в списке!");
            }
        }
        //удалить издателя
        private void delete_Publisher(object sender, EventArgs e)
        {
            string selectedItem = publishersCombobox.SelectedItem.ToString();

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный элемент из списка?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                for (int i = bindingListBook.Count - 1; i >= 0; i--)
                {
                    if (bindingListBook[i].Publisher == selectedItem)
                    {
                        bindingListBook.RemoveAt(i);
                    }
                }

                deleteComboboxValue(selectedItem, bindingListPublishers);
            }
        }

     

        void SortTable(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Book> list = bindingListBook.ToList();
            // Сортируем список на основе нажатого заголовка столбца
            list.Sort((Book a, Book b) =>
            {
                if (e.RowIndex == -1)
                {
                    int columnIndex = e.ColumnIndex;

                    if (columnIndex == 0) // Сортируем по названию
                    {
                        return sortAscending ? a.Title.CompareTo(b.Title) : b.Title.CompareTo(a.Title);
                    }
                    else if (columnIndex == 1) // Сортируем по автору
                    {
                        return sortAscending ? a.Author.CompareTo(b.Author) : b.Author.CompareTo(a.Author);
                    }
                    else if (columnIndex == 2) // Сортируем по издателю
                    {
                        return sortAscending ? a.Publisher.CompareTo(b.Publisher) : b.Publisher.CompareTo(a.Publisher);
                    }
                    else if (columnIndex == 3) // Сортируем по году выпуска
                    {
                        return sortAscending ? a.Year.CompareTo(b.Year) : b.Year.CompareTo(a.Year);
                    }
                }

                return 0;
            });

            bindingListBook = new BindingList<Book>(list);
            dataGridView1.DataSource = bindingListBook;
            sortAscending = !sortAscending;
        }

        // Json
        private void Import_json(object sender, EventArgs e)
        {
            // Создаем диалоговое окно для выбора файла и задаем фильтр по типу файлов
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (.json)|.json|All files (.)|.";
            openFileDialog.Title = "Select a JSON file";

            // Если пользователь выбрал файл и нажал "ОК"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                string json = File.ReadAllText(filename);


                BindingList<Book> importedBooks = JsonSerializer.Deserialize<BindingList<Book>>(json);

                bindingListBook.Clear();
                foreach (Book book in importedBooks)
                {
                    bindingListBook.Add(book);
                }

                dataGridView1.DataSource = bindingListBook;
            }
        }

        // Обработчик события нажатия на кнопку экспорта
        private void Export_json(object sender, EventArgs e)
        {
            // Сериализуем bindingListBook в JSON-строку с отступами
            string json = JsonSerializer.Serialize(bindingListBook, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText("D:/cool/.json", json);

                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            bindingListBook.Clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void newAuthorName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}