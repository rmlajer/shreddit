namespace shreddit.Model
{
    public class Comment
    {
        public Comment(string text = "", string user = "", int postId = 0)
        {
            this.Text = text;
            this.User = user;
            this.PostId = postId;
            this.Time = DateTime.Now;
        }

        public int CommentId { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public int PostId { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }

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
