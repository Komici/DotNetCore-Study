using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XunitTestDemo
{
    public interface IArticleService
    {
        int GetCount();
    }

    public class ArticleService: IArticleService
    {
        public int GetCount()
        {
            return 2;
        }
    }
}
