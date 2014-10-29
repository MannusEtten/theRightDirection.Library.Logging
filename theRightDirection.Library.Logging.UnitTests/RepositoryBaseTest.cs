using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using theRightDirection.Library.Entities;
using theRightDirection.Library.Repositories;

namespace theRightDirection.Library.UnitTests
{
    [TestClass]
    public class RepositoryBaseTest
    {
        [TestMethod]
        public void Select_By_Id_With_Empty_Collection_Expect_Null()
        {
            MockRepository repository = new MockRepository(false);
            MockEntity me = repository.Select(1);
            Assert.IsNull(me);
        }

        [TestMethod]
        public void Select_By_Id_With_Full_Collection_But_Non_Existing_Id_Expect_Null()
        {
            MockRepository repository = new MockRepository(true);
            MockEntity me = repository.Select(100);
            Assert.IsNull(me);
        }

        [TestMethod]
        public void Select_By_Id_With_Full_Collection_And_Existing_Id_Returns_Entity()
        {
            MockRepository repository = new MockRepository(true);
            MockEntity entity = repository.Select(2);
            Assert.AreEqual(2, entity.Id);
            Assert.AreEqual("Pietje", entity.Name);
        }

        [TestMethod]
        public void Select_Returns_Null_When_Empty_Collection()
        {
            MockRepository repository = new MockRepository(false);
            IEnumerable<MockEntity> list = repository.Select();
            Assert.IsNull(list);
        }

        [TestMethod]
        public void Select_Returns_Items_When_Collection_Is_Not_Empty()
        {
            MockRepository repository = new MockRepository(true);
            IEnumerable<MockEntity> list = repository.Select();
            Assert.AreNotEqual(0, list.Count());
        }

        [TestMethod]
        public void Select_By_Indexer_With_Empty_Collection_Expect_Null()
        {
            MockRepository repository = new MockRepository(false);
            MockEntity me = repository[1];
            Assert.IsNull(me);
        }

        [TestMethod]
        public void Select_By_Indexer_With_Full_Collection_But_Non_Existing_Id_Expect_Null()
        {
            MockRepository repository = new MockRepository(true);
            MockEntity me = repository[100];
            Assert.IsNull(me);
        }

        [TestMethod]
        public void Select_By_Indexer_With_Full_Collection_And_Existing_Id_Returns_Entity()
        {
            MockRepository repository = new MockRepository(true);
            MockEntity entity = repository[2];
            Assert.AreEqual(2, entity.Id);
            Assert.AreEqual("Pietje", entity.Name);
        }

        private class MockEntity : EntityBase
        {
            public string Name { get; set; }
        }

        private class MockRepository2<T> : RepositoryBase<T> where T: EntityBase, new()
        {
            public MockRepository2()
            {

            }

            public override void Insert(T entity)
            {
                throw new NotImplementedException();
            }

            public override void Update(T entity)
            {
                throw new NotImplementedException();
            }

            public override void Delete(T entity)
            {
                throw new NotImplementedException();
            }

            protected override void LoadEntities()
            {
                throw new NotImplementedException();
            }
        }

        private class MockRepository : MockRepository2<MockEntity>
        {
            public MockRepository(bool withItemsLoaded)
            {
                if (withItemsLoaded)
                {
                    List<MockEntity> items = new List<MockEntity>();
                    items.Add(new MockEntity() { Id = 1, Name = "Mannus" });
                    items.Add(new MockEntity() { Id = 2, Name = "Pietje" });
                    items.Add(new MockEntity() { Id = 3, Name = "Klaasje" });
                    _entities = items;
                }
            }

            public override void Insert(MockEntity entity)
            {
                throw new NotImplementedException();
            }

            public override void Update(MockEntity entity)
            {
                throw new NotImplementedException();
            }

            public override void Delete(MockEntity entity)
            {
                throw new NotImplementedException();
            }

            protected override void LoadEntities()
            {
            }
        }
    }
}