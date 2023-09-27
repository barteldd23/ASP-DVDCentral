using DVDCentral.BL.Models;

namespace DDB.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Genre> list = GenreManager.Load();
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Genre genre = new Genre
            {
                Description = "Test",
                Id = -99
            };
            int result = GenreManager.Insert(genre, true);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Genre genre = new Genre
            {
                Description = "Test",
                Id = 1
            };
            int result = GenreManager.Delete(genre, true);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Genre genre = new Genre
            {
                Description = "Test",
                Id = 1
            };
            int result = GenreManager.Update(genre, true);
            Assert.AreEqual(1, result);
        }
    }
}