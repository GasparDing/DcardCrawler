using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcardCrawler
{
    public interface IApiService<TKey, TModel>
    {
        bool Create(TModel model);

        ICollection<TModel> Read();

        bool? Update(TKey key);

        bool? Delete(TKey key);
    }
}
