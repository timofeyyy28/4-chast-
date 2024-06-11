using ClassLibraryLabor10;
using lab12._4;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_AddsItem_CountIncreases()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument = new Musicalinstrument("Piano", 1);
            collection.Add(instrument);
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void RemoveAt_RemoveAtIndex_ElementRemoved()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Guitar", 1);
            var instrument2 = new Musicalinstrument("Violin", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);
            collection.RemoveAt(0);
            Assert.AreEqual(1, collection.Count);
            Assert.IsFalse(collection.Contains(instrument1));
        }

        [TestMethod]
        public void IndexOf_ItemExists_ReturnsCorrectIndex()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Drums", 1);
            var instrument2 = new Musicalinstrument("Flute", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);
            int index = collection.IndexOf(instrument2);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void IndexOf_ItemDoesNotExist_ReturnsNegativeOne()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Saxophone", 1);
            var instrument2 = new Musicalinstrument("Trumpet", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);
            var instrument3 = new Musicalinstrument("Trombone", 3);
            int index = collection.IndexOf(instrument3);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void Insert_InsertsItemAtIndex()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Keyboard", 1);
            var instrument2 = new Musicalinstrument("Harp", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);
            var instrument3 = new Musicalinstrument("Accordion", 3);
            collection.Insert(1, instrument3);
            Assert.AreEqual(instrument3, collection[1]);
        }

        [TestMethod]
        public void Contains_ItemExists_ReturnsTrue()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Xylophone", 1);
            var instrument2 = new Musicalinstrument("Cello", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);
            bool contains = collection.Contains(instrument2);
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void Contains_ItemDoesNotExist_ReturnsFalse()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Banjo", 1);
            var instrument2 = new Musicalinstrument("Double Bass", 2);
            collection.Add(instrument1);
            bool contains = collection.Contains(instrument2);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void CopyTo_CopiesItemsToArray()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Mandolin", 1);
            var instrument2 = new Musicalinstrument("Bagpipe", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);
            Musicalinstrument[] array = new Musicalinstrument[2];
            collection.CopyTo(array, 0);
            CollectionAssert.AreEqual(new Musicalinstrument[] { instrument1, instrument2 }, array);
        }

        [TestMethod]
        public void Remove_RemovesItem_ReturnsTrue()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Tuba", 1);
            var instrument2 = new Musicalinstrument("Harmonica", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);
            bool removed = collection.Remove(instrument2);
            Assert.IsTrue(removed);
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void Remove_ItemDoesNotExist_ReturnsFalse()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Organ", 1);
            var instrument2 = new Musicalinstrument("Synthesizer", 2);
            collection.Add(instrument1);
            bool removed = collection.Remove(instrument2);
            Assert.IsFalse(removed);
            Assert.AreEqual(1, collection.Count);
        }
        [TestMethod]
        public void GetEnumerator_MoveNext_ReturnsCorrectOrder()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Piano", 1);
            var instrument2 = new Musicalinstrument("Guitar", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);

            var enumerator = collection.GetEnumerator();
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(instrument1, enumerator.Current);
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(instrument2, enumerator.Current);
            Assert.IsFalse(enumerator.MoveNext());
        }

        [TestMethod]
        public void GetEnumerator_Reset_ReturnsToInitialState()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Piano", 1);
            var instrument2 = new Musicalinstrument("Guitar", 2);
            collection.Add(instrument1);
            collection.Add(instrument2);

            var enumerator = collection.GetEnumerator();
            enumerator.MoveNext();
            enumerator.Reset();

            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(instrument1, enumerator.Current);
        }       

        [TestMethod]
        public void Insert_InsertsItemAtEnd()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Piano", 1);
            var instrument2 = new Musicalinstrument("Guitar", 2);
            var instrument3 = new Musicalinstrument("Violin", 3);

            collection.Add(instrument1);
            collection.Add(instrument2);
            collection.Insert(2, instrument3);

            Assert.AreEqual(instrument1, collection[0]);
            Assert.AreEqual(instrument2, collection[1]);
            Assert.AreEqual(instrument3, collection[2]);
        }

        [TestMethod]
        public void RemoveAt_RemovesItemAtBeginning()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Piano", 1);
            var instrument2 = new Musicalinstrument("Guitar", 2);
            var instrument3 = new Musicalinstrument("Violin", 3);

            collection.Add(instrument1);
            collection.Add(instrument2);
            collection.Add(instrument3);
            collection.RemoveAt(0);

            Assert.AreEqual(2, collection.Count);
            Assert.IsFalse(collection.Contains(instrument1));
            Assert.AreEqual(instrument2, collection[0]);
            Assert.AreEqual(instrument3, collection[1]);
        }

        [TestMethod]
        public void RemoveAt_RemovesItemAtEnd()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Piano", 1);
            var instrument2 = new Musicalinstrument("Guitar", 2);
            var instrument3 = new Musicalinstrument("Violin", 3);

            collection.Add(instrument1);
            collection.Add(instrument2);
            collection.Add(instrument3);
            collection.RemoveAt(2);

            Assert.AreEqual(2, collection.Count);
            Assert.IsFalse(collection.Contains(instrument3));
            Assert.AreEqual(instrument1, collection[0]);
            Assert.AreEqual(instrument2, collection[1]);
        }
        [TestMethod]
        public void Remove_RemoveMultipleItems_CountDecreases()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Piano", 1);
            var instrument2 = new Musicalinstrument("Guitar", 2);
            var instrument3 = new Musicalinstrument("Violin", 3);

            collection.Add(instrument1);
            collection.Add(instrument2);
            collection.Add(instrument3);

            collection.Remove(instrument1);
            collection.Remove(instrument2);

            Assert.AreEqual(1, collection.Count);
            Assert.IsFalse(collection.Contains(instrument1));
            Assert.IsFalse(collection.Contains(instrument2));
            Assert.IsTrue(collection.Contains(instrument3));
        }
        [TestMethod]
        public void Insert_InsertsItemAtBeginning()
        {
            var collection = new MyCollection<Musicalinstrument>();
            var instrument1 = new Musicalinstrument("Piano", 1);
            var instrument2 = new Musicalinstrument("Guitar", 2);
            var instrument3 = new Musicalinstrument("Violin", 3);

            collection.Add(instrument2);
            collection.Add(instrument3);
            collection.Insert(0, instrument1);

            Assert.AreEqual(3, collection.Count);
            Assert.IsTrue(collection.Contains(instrument1));
            Assert.AreEqual(instrument1, collection[0]);
            Assert.AreEqual(instrument2, collection[1]);
            Assert.AreEqual(instrument3, collection[2]);
        }
    }
}

