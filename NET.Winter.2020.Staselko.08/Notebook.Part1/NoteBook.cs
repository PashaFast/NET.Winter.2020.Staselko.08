using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    /// <summary>
    /// Classc NoteBook.
    /// </summary>
    public class NoteBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteBook"/> class.
        /// </summary>
        public NoteBook()
        {
            this.Notes = new List<Note>();
        }

        /// <summary>
        /// Gets property.
        /// </summary>
        /// <value>
        /// List of Notes.
        /// </value>
        public List<Note> Notes { get; }
    }
}
