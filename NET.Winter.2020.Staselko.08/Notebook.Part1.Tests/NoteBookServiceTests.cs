using NUnit.Framework;
using System;

namespace Notebook.Part1.Tests
{
    public class NoteBookServiceTests
    {
        [Test, Order(1)]
        public void CreateRecord_WithOneNote()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            noteBook.CreateRecord("first", "blblabla", "PashaFast");
            string actual = noteBook.ToString();
            string expected1 = $"#1, first, {DateTime.Now}, blblabla; ";
            string expected = $"#1, first was written by PashaFast in {DateTime.Now}. Add has next text blblabla; ";
            Assert.AreEqual(expected, actual);
        }

        [Test, Order(2)]
        public void CreateRecord_WithTwoNote()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            noteBook.DeleteRecord(1);
            noteBook.CreateRecord("first", "blblabla", "PashaFast");
            noteBook.CreateRecord("second", "some content", "John Skeet");
            string actual = noteBook.ToString();
            string expected = $"#1, first was written by PashaFast in {DateTime.Now}. Add has next text blblabla; " +
                $"#2, second was written by John Skeet in {DateTime.Now}. Add has next text some content; ";
            Assert.AreEqual(expected, actual);
        }

        [Test, Order(3)]
        public void EditRecord_WithTwoNote()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            noteBook.EditRecord(2, "fourth", "la-la-la", "AnzhelikaKravchuk");
            string actual = noteBook.ToString();
            string expected = $"#1, first was written by PashaFast in {DateTime.Now}. Add has next text blblabla; " +
                $"#2, fourth was written by AnzhelikaKravchuk in {DateTime.Now}. Add has next text la-la-la; ";
            Assert.AreEqual(expected, actual);
        }

        [Test, Order(4)]
        public void DeleteOneRecord_WithTwoNote()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            noteBook.DeleteRecord(2);
            string actual = noteBook.ToString();
            string expected = $"#1, first was written by PashaFast in {DateTime.Now}. Add has next text blblabla; ";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateRecord_WithNullTitle_ThrowArgumentNullException()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            Assert.Throws<ArgumentNullException>(() => noteBook.CreateRecord(null, "blblabla", "PashaFast"),
            "title must not be null");
        }

        [Test]
        public void CreateRecord_WithNullText_ThrowArgumentNullException()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            Assert.Throws<ArgumentNullException>(() => noteBook.CreateRecord("first", null, "PashaFast"),
            "content must not be null");
        }

        [Test]
        public void CreateRecord_WithEmptyTitle_ThrowArgumentNullException()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            Assert.Throws<ArgumentNullException>(() => noteBook.CreateRecord(null, "some text", "PashaFast"),
            "title must not be empty");
        }

        [Test]
        public void CreateRecord_WithEmptyText_ThrowArgumentNullException()
        {
            NoteBookService noteBook = NoteBookService.GetInstance();
            Assert.Throws<ArgumentException>(() => noteBook.CreateRecord("lalala", "  ", "PashaFast"),
            "conent must not be empty");
        }

    }
}