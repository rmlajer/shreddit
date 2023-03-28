using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace shreddit.Model
{
    public class Post
    {
        public Post(string title = "", string text = "", string user = "")
        {
            this.Title = title;
            this.Text = text;
            this.User = user;
            this.Time = DateTime.Now;
            this.Comments = new List<Comment>();
        }


        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }
        public List<Comment> Comments { get; set; }

        public void ChangeScore(bool b)
        {
            if (b)
            {
                Score++;
            }
            else if (!b)
            {
                Score--;
            }
        }
    }

}
