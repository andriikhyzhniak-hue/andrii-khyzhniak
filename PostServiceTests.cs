using NUnit.Framework;
using System;
using FaceCloude;

namespace FaceCloude.Tests
{
    [TestFixture]
    public class PostServiceTests
    {
        [Test]
        public void CreatePost_ValidText_ShouldCreatePost()
        {
            PostService service = new PostService();

            service.CreatePost("Test post");

            Assert.Pass();
        }

        [Test]
        public void CreatePost_EmptyText_ShouldThrow()
        {
            PostService service = new PostService();

            Assert.Throws<ArgumentException>(
                () => service.CreatePost(""));
        }

        [Test]
        public void CreatePost_Null_ShouldThrow()
        {
            PostService service = new PostService();

            Assert.Throws<ArgumentException>(
                () => service.CreatePost(null));
        }

        [Test]
        public void CreatePost_Length1_ShouldPass()
        {
            PostService service = new PostService();

            service.CreatePost("A");

            Assert.Pass();
        }

        [Test]
        public void CreatePost_Length500_ShouldPass()
        {
            PostService service = new PostService();

            string text = new string('A', 500);

            service.CreatePost(text);

            Assert.Pass();
        }

        [Test]
        public void CreatePost_Length501_ShouldThrow()
        {
            PostService service = new PostService();

            string text = new string('A', 501);

            Assert.Throws<ArgumentException>(
                () => service.CreatePost(text));
        }

        [Test]
        public void SearchPosts_ExistingKeyword()
        {
            PostService service = new PostService();

            service.CreatePost("Hello World");

            Assert.AreEqual(
                1,
                service.SearchPosts("Hello").Count);
        }

        [Test]
        public void SearchPosts_NotExistingKeyword()
        {
            PostService service = new PostService();

            service.CreatePost("Hello World");

            Assert.AreEqual(
                0,
                service.SearchPosts("Java").Count);
        }

        [Test]
        public void DeletePost_ValidIndex()
        {
            PostService service = new PostService();

            service.CreatePost("Test");

            Assert.IsTrue(service.DeletePost(0));
        }

        [Test]
        public void DeletePost_InvalidIndex()
        {
            PostService service = new PostService();

            Assert.IsFalse(service.DeletePost(-1));
        }
    }
}
