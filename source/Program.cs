using PokeProject.Objects;
using PokeProject.Request;

string name = "";
string line = "------------------------------------------------------------";
PokeRequest request = new();
Pokemon Pokemon = new Pokemon();
Start();
void Start()
{
    Console.WriteLine($@"{line}
              _                    _       _     _ 
  _ __   ___ | | _____  __ _  ___ | |_ ___| |__ (_)
 | '_ \ / _ \| |/ / _ \/ _` |/ _ \| __/ __| '_ \| |
 | |_) | (_) |   <  __/ (_| | (_) | || (__| | | | |
 | .__/ \___/|_|\_\___|\__, |\___/ \__\___|_| |_|_|
 |_|                   |___/
{line}

Qual o seu nome?");
    while (name == "")
    {
        try { name = Console.ReadLine().ToString().Split(' ')[0]; }
        catch { }
    }
    Menu();
}
void Menu()
{
    Console.Clear();
    Console.WriteLine("--------------------------- MENU ---------------------------");
    if(Pokemon.name == null) 
    { 
        Console.WriteLine($"{name} você deseja:\n1 - Adotar um mascote virtual\n2 - Sair"); 
    }
    else
    {
        Console.WriteLine($"{name} você deseja:\n1 - Ver seu pokémon\n2 - Sair");
    }
    while (true)
    {
        try
        {
            switch (Console.ReadLine())
            {
                case "1":
                    if (Pokemon.name == null) { AdoptPokemon(); }
                    else { YourPet(); }
                    return;
                case "2":
                    return;
                default:
                    Console.WriteLine("Essa opção não existe!");
                    break;
            }
        }
        catch { }
    }
}
void YourPet()
{
    string txt = @$"

1 - Alimentar
2 - Hidratar
3 - Brincar
4 - Colocar para dormir
5 - Voltar";
    string update = "";
    Console.Clear();
    Console.WriteLine($@"------------------- SEU POKEMON VIRTUAL --------------------
{Pokemon.ToString}" + txt);
    while (true)
    {
        try
        {
            switch (Console.ReadLine())
            {
                case "1":
                    update = Pokemon.Food();
                    break;
                case "2":
                    update = Pokemon.Drink();
                    break;
                case "3":
                    update = Pokemon.Play();
                    break;
                case "4":
                    update = Pokemon.Sleep();
                    break;
                case "5":
                    Menu();
                    return;
                default:
                    Console.WriteLine("Essa opção não existe!");
                    break;
            }
            Console.Clear();
            Console.WriteLine($@"------------------- SEU POKEMON VIRTUAL --------------------
{Pokemon.ToString}"+txt);
            Console.WriteLine(update);
        }
        catch { }
    }
}
void AdoptPokemon()
{
    Console.Clear();
    Console.WriteLine("-------------------------- ADOTAR --------------------------");
    Console.WriteLine($"{name} escolha uma espécie:\n");
    while(true)
    {
        try
        {
            string pokemon = Console.ReadLine();
            if (request.ValidatePokemon(pokemon) == false) 
            {
                Console.WriteLine("Pokemón inválido!");
            }
            else
            {
                NewPokemon(pokemon);
                return;
            }
        }
        catch { }
    }
}
void NewPokemon(string pokemonName)
{
    Pokemon pokemon = request.GetPokemon(pokemonName);
    while(true)
    {
        Console.Clear();
        Console.WriteLine($"{line}\n{name} você deseja:\n1 - Saber mais sobre {pokemonName}\n2 - Adotar {pokemonName}\n3 - Voltar");
        try
        {
            switch(Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(@$"{line}
Nome do pokemon: {pokemon.name}
Altura: {pokemon.height}
Peso: {pokemon.weight}
Habilidades:"); 
                    foreach (var a in pokemon.abilities)
                    {
                        Console.WriteLine(a.ability.name);
                    }
                    Console.WriteLine("Aparte qualquer tecla para voltar!");
                    Console.ReadKey();
                    break;
                case "2":
                    Pokemon = pokemon;
                    Console.WriteLine($"Qual será o nome do seu {pokemonName}?");
                    while(Pokemon.nickname == "")
                    {
                        Pokemon.nickname = Console.ReadLine();
                    }
                    Console.WriteLine("Pokémon adotado! Aparte qualquer tecla para prosseguir");
                    Console.ReadKey();
                    Menu();
                    return;
                case "3":
                    Menu();
                    return;
            }
        }
        catch { }
    }
}
