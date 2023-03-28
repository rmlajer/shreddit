using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using shreddit.Data;
using shreddit.Model;

namespace shreddit.Service
{
    public class DataService
    {
        private DataContext db { get; }

        public DataService(DataContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Seeder noget nyt data i databasen hvis det er nødvendigt.
        /// </summary>
        public void SeedData()
        {

            Post post = db.Posts.FirstOrDefault()!;
            if (post == null)
            {
                post = new Post { Title = "TestPost1", Text = "Please", User = "TestUser1" };
                db.Posts.Add(post);
                db.Posts.Add(new Post { Title = "TestPost2", Text = "Please", User = "TestUser2" });
                db.SaveChanges();

                db.Comments.Add(new Comment { Text = "TestPostComment1", User = "TestUser2", PostId = 1 });
                db.Comments.Add(new Comment { Text = "TestPostComment1", User = "TestUser2", PostId = 1 });


            }

            db.SaveChanges();
        }

        
        public List<Post> GetPosts()
        {
            return db.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return db.Posts.Include(p => p.Comments).First(p => p.PostId == id);
        }

        public List<Comment> GetComments()
        {
            return db.Comments.ToList();
        }

        public string CreateComment(string text, string user, int postId)
        {
            db.Comments.Add(new Comment { Text = text, User = user, PostId = postId });
            db.SaveChanges();
            return "Comment added";
        }

        public string CreatePost(string text, string user, string title)
        {
            db.Posts.Add(new Post { Text = text, User = user, Title = title });
            db.SaveChanges();
            return "Post added";
        }

        public string ChangePostScore(bool b, int id)
        {
            db.Posts.First(p => p.PostId == id).ChangeScore(b);
            db.SaveChanges();
            if (b) { return "Score added"; }
            else if (!b) { return "Score subtracted"; }
            else return "No work";
        }

        public string ChangeCommentScore(bool b, int id)
        {
            db.Comments.First(p => p.CommentId == id).ChangeScore(b);
            db.SaveChanges();
            if (b) { return "Score added"; }
            else if (!b) { return "Score subtracted"; }
            else return "No work";
        }

    }
}

