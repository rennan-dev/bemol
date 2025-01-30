namespace Estoque.EventProcessor;

public interface IProcessaEvento {
    public Task ProcessaAsync(string mensagem);
}