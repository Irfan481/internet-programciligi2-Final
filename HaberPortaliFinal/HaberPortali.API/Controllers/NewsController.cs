using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HaberPortali.Dtos;
using HaberPortali.Models;
using Microsoft.AspNetCore.Authorization;

namespace HaberPortali.Controllers
{
    [Route("api/News")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public NewsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<NewsDto> GetList()
        {
            var news = _context.News.ToList();
            var newsDtos = _mapper.Map<List<NewsDto>>(news);
            return newsDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public NewsDto Get(int id)
        {
            var news = _context.News.Where(s => s.Id == id).SingleOrDefault();
            var newsDto = _mapper.Map<NewsDto>(news);
            return newsDto;
        }

        [HttpPost]
        public ResultDto Post(NewsDto dto)
        {
            if (_context.News.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Ürün Adı Kayıtlıdır!";
                return result;
            }
            var news = _mapper.Map<News>(dto);
            news.Updated = DateTime.Now;
            news.Created = DateTime.Now;
            _context.News.Add(news);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(NewsDto dto)
        {
            var news = _context.News.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (news == null)
            {
                result.Status = false;
                result.Message = "Ürün Bulunamadı!";
                return result;
            }
            news.Name = dto.Name;
            news.IsActive = dto.IsActive;
            news.Page = dto.Page;
            news.Updated = DateTime.Now;
            news.CategoryId = dto.CategoryId;
            _context.News.Update(news);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var news = _context.News.Where(s => s.Id == id).SingleOrDefault();
            if (news == null)
            {
                result.Status = false;
                result.Message = "Ürün Bulunamadı!";
                return result;
            }
            _context.News.Remove(news);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Silindi";
            return result;
        }
    }
}
