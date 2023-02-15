namespace PokeProject.Objects
{
    public class Pokemon
    {
        public Pokemon()
        {
            hungry = 8;
            thirst = 9;
            energy = 7;
            happiness = 2;
            nickname = "";
        }
        public List<Abilities> abilities { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public int id { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int hungry { get; set; }
        public int thirst { get; set; }
        public int energy { get; set; }
        public int happiness { get; set; }
        public new string ToString => @$"Nome: {nickname}
Tipo: {name}
Altura: {height}
Peso: {weight}

|--------Status--------|
| Alimentação: {hungry}/10   |
| Hidratação: {thirst}/10    |
| Felicidade: {happiness}/10    |
| Energia: {energy}/10       |
|----------------------|";
        public string Food()
        {
            if (energy == 0) { return $"{nickname} está cansado demais para se alimentar!"; }
            if (hungry == 10){ return $"{nickname} já está cheio!"; }
            hungry = 10;
            energy--;
            return $"{nickname} foi alimentado!";
        }
        public string Drink()
        {
            if (energy == 0) { return $"{nickname} está cansado demais para se hidratar!"; }
            if(thirst == 10){ return $"{nickname} já está hidratado!";}
            thirst = 10;
            energy--;
            return $"{nickname} foi hidratado!";
        }
        public string Play()
        {
            if(happiness == 10) { return $"{nickname} já brincou o bastante!"; }
            if(energy == 0) { return $"{nickname} está cansado demais para brincar!"; }
            if(thirst == 0) { return $"{nickname} está com sede!"; }
            if(hungry == 0) { return $"{nickname} está com fome!"; }
            energy--;
            hungry--;
            thirst--;
            happiness = 10;
            return $"{nickname} brincou bastante!";
        }
        public string Sleep()
        {
            if(happiness != 0) { happiness -= 2; }
            if (hungry != 0) { hungry--; }
            if (thirst != 0) { thirst--; }
            if (energy == 10) { return $"{nickname} já dormiu!"; }
            energy = 10;
            return $"{nickname} dormiu!";
        }
    }
    public class Abilities
    {
        public Ability ability { get; set; }
    }
    public class Ability
    {
        public string name { get; set; }
    }

}
