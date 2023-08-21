using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTOS.Endereco;
using FilmesApi.ExceptionFilter;
using FilmesApi.Models;

namespace FilmesApi.Service;
public class EnderecoService
{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    public EnderecoService(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<ReadEnderecoDTO> FindAll()
    {
        return _mapper.Map<List<ReadEnderecoDTO>>(_context.Enderecos);
    }

    public ReadEnderecoDTO FindId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);
        ReadEnderecoDTO enderecoDto = _mapper.Map<ReadEnderecoDTO>(endereco);

        if (endereco == null)
        {
            throw new StudentNotFoundException("Está lista está vazia");
        }

        return enderecoDto;
    }

    public CreateEnderecoDTO CreateEndereco(CreateEnderecoDTO enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return enderecoDto;
    }

    public UpdateEnderecoDTO UpdateEndereco(int id, UpdateEnderecoDTO enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);

        if (endereco == null)
        {
            throw new StudentNotFoundException("Not Found");
        }

        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return enderecoDto;
    }

    public ReadEnderecoDTO DeleteEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.id == id);
        ReadEnderecoDTO enderecoView = _mapper.Map<ReadEnderecoDTO>(endereco);

        if (endereco == null)
        {
            throw new StudentNotFoundException("Not Found");
        }

        _context.Remove(endereco);
        _context.SaveChanges();
        return enderecoView;
    }
}
