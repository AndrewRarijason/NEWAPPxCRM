namespace newApp.Service

{
    public class LoginService
    {
        public async Task<bool> IsValid(string Username, string Password)
        {
            using var client = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("username", Username),
                    new KeyValuePair<string, string>("password", Password)
                });
            
            //alefa any am api le content ho testeny
            var response = await client.PostAsync("http://localhost:8080/api/login", content);
            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result); // Ne pas supprimer cette ligne

            // Vérifie que le status HTTP est 200 et que le contenu de la réponse indique un succès
            return response.IsSuccessStatusCode && result.Contains("true");
        }
    }
}
