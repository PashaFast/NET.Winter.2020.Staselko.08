using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    /// <summary>
    /// Class NoteBookService.
    /// </summary>
    public class NoteBookService : IView
    {
        private static NoteBookService instance;

        private NoteBook notebook = new NoteBook();

        private NoteBookService()
        {
        }

        /// <summary>
        /// GetInstance method.
        /// </summary>
        /// <returns>instance on NoteBookService.</returns>
        public static NoteBookService GetInstance()
        {
            if (instance == null)
            {
                instance = new NoteBookService();
            }

            return instance;
        }

        /// <summary>
        /// CreateRecord method.
        /// </summary>
        /// <param name="title">Title of Note.</param>
        /// <param name="text">text contained in the note.</param>
        /// <param name="author">Author of Note.</param>
        public void CreateRecord(string title, string text, string author)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                if (text is null)
                {
                    throw new ArgumentNullException(nameof(text), "cannot not be null!");
                }
                else
                {
                    throw new ArgumentException("must contain at least one symbols except space");
                }
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                if (title is null)
                {
                    throw new ArgumentNullException(nameof(title), "must not be null!");
                }
                else
                {
                    throw new ArgumentException("must contain at least one symbols except space");
                }
            }

            DateTime date = DateTime.Now;
            var record = new Note(author, title, text, date, this.notebook.Notes.Count + 1);
            this.notebook.Notes.Add(record);
        }

        /// <summary>
        /// EditRecord method(by id).
        /// </summary>
        /// <param name="id">id of Note.</param>
        /// <param name="title">NEW Title of Note.</param>
        /// <param name="text">NEW text.</param>
        /// <param name="author">NEW Author of Note.</param>
        public void EditRecord(int id, string title, string text, string author)
        {
            if (this.notebook.Notes.Count < id)
            {
                throw new ArgumentException("Current id is not found");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                if (text is null)
                {
                    throw new ArgumentNullException(nameof(text), "must not be null!");
                }
                else
                {
                    throw new ArgumentException("must contain at least two symbols except space");
                }
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                if (title is null)
                {
                    throw new ArgumentNullException(nameof(title), "must not be null!");
                }
                else
                {
                    throw new ArgumentException("must contain at least one symbols except space");
                }
            }

            DateTime date = DateTime.Now;
            var record = new Note(author, title, text, date, id);

            this.notebook.Notes[id - 1] = record;
        }

        /// <summary>
        /// DeleteRecord method(by id).
        /// </summary>
        /// <param name="id">id.</param>
        public void DeleteRecord(int id)
        {
            if (this.notebook.Notes.Count < id)
            {
                throw new ArgumentException("Current id is not found");
            }

            this.notebook.Notes.RemoveAt(id - 1);
        }

        /// <summary>
        /// Render method.
        /// </summary>
        /// <param name="title">Titles of Notes with whom we will work.</param>
        public void Render(params string[] title)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title), "must not be null!");
            }

            if (title.Length == 0)
            {
                this.Show(this.notebook.Notes);
            }
            else
            {
                List<Note> result = new List<Note>();
                this.AddToListIfMatch(result, title);
                if (result.Count != 0)
                {
                    this.Show(result);
                }
                else
                {
                    Console.WriteLine("Nothing is found");
                }
            }
        }

        /// <summary>
        /// ToString mehod.
        /// </summary>
        /// <returns>string representation of an object.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var obj in this.notebook.Notes)
            {
                stringBuilder.Append(obj.ToString() + "; ");
            }

            return stringBuilder.ToString();
        }

        private void Show(List<Note> result)
        {
            foreach (var record in result)
            {
                Console.WriteLine(record.ToString());
            }
        }

        private void AddToListIfMatch(List<Note> result, params string[] title)
        {
            foreach (var record in this.notebook.Notes)
            {
                foreach (var note in title)
                {
                    if (note == record.Title)
                    {
                        result.Add(record);
                    }
                }
            }
        }
    }
}
