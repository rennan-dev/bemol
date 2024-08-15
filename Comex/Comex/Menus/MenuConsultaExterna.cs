using Comex.Modelos;
using System.Text.Json;

namespace Comex.Menus;
internal class MenuConsultaExterna : Menu {
    public async Task ConsultaExternaAsync() {
        Console.Clear();
        using (HttpClient cliente = new HttpClient()) {
            try {
                string resposta = await cliente.GetStringAsync("https://fakestoreapi.com/products");
                var produtosFakeStore = JsonSerializer.Deserialize<List<FakeStoreApi>>(resposta);

                if(produtosFakeStore != null && produtosFakeStore.Count > 0) {
                    var fakeStoreApi = new FakeStoreApi();
                    fakeStoreApi.ExibirProdutos(produtosFakeStore);
                }else {
                    Console.WriteLine("Nenhum produto encontrado na FakeStoreAPI.");
                }
            }catch (Exception ex) {
                Console.WriteLine($"Temos um erro: {ex.ToString()}");
            }
        }
        Console.Write("\nDigite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
