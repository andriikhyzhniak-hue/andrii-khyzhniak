using System;
using System.Collections.Generic;

namespace FaceCloude
{
    public class PostService
    {
        private List<string> posts = new List<string>();

        public void CreatePost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Публікація не може бути порожньою");

            if (content.Length > 500)
                throw new ArgumentException("Перевищено максимальну довжину");

            posts.Add(content);
        }

        public List<string> SearchPosts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ArgumentException("Ключове слово порожнє");

            List<string> result = new List<string>();

            foreach (string post in posts)
            {
                if (post.ToLower().Contains(keyword.ToLower()))
                {
                    result.Add(post);
                }
            }

            return result;
        }

        public bool DeletePost(int index)
        {
            if (index < 0 || index >= posts.Count)
                return false;

            posts.RemoveAt(index);
            return true;
        }
    }
}
