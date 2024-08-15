using A1Template.Models;
using A1Template.Dtos;
using System.Collections.Generic;

namespace A1Template.Data
{
    public interface IA1Repo
    {
        IEnumerable<Sign> GetAllSigns();
        IEnumerable<Sign> FindSigns(string searchTerm);
        string GetSignImagePath(string id);
        Comment GetCommentById(int id);
        Comment AddComment(CommentInput input);
        IEnumerable<Comment> GetLatestComments(int number);
    }
}
