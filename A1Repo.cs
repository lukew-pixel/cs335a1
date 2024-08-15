using A1Template.Models;
using A1Template.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace A1Template.Data
{
    public class A1Repo : IA1Repo
    {
        private readonly A1DbContext _context;

        public A1Repo(A1DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sign> GetAllSigns()
        {
            return _context.Signs.ToList();
        }

        public IEnumerable<Sign> FindSigns(string searchTerm)
        {
            return _context.Signs
                .Where(s => s.Description.Contains(searchTerm))
                .ToList();
        }

        public string GetSignImagePath(string id)
        {
            var path = Path.Combine("SignsImages", id + ".png");
            return File.Exists(path) ? path : Path.Combine("SignsImages", "default.png");
        }

        public Comment GetCommentById(int id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public Comment AddComment(CommentInput input)
        {
            var comment = new Comment
            {
                Name = input.Name,
                UserComment = input.UserComment,
                Time = System.DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ"),
                IP = "127.0.0.1" // Placeholder for actual IP retrieval
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return comment;
        }

        public IEnumerable<Comment> GetLatestComments(int number)
        {
            return _context.Comments
                .OrderByDescending(c => c.Id)
                .Take(number)
                .ToList();
        }
    }
}
