namespace lista_magyarazas;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // tegyk fel, egy játékban van a karakternek egy inventory-ja
        // ezt lehet úgy is, hogy egy tömbben tároljuk, ahol fix mennyiségű inventory slot van, mint pl. Minecraft, Undertale, Subnautica
        string[] inventory = new string[5]; // 5 slot
        inventory[0] = "Kard";
        inventory[1] = "Pajzs";
        inventory[2] = "Életerő ital";
        // satöbbi.. (a listát a copilot írta, nem én :D)

        // de mi van, ha egy egy olyan RPG játékban vagyunk, ahol végtelen mennyíségű tárgyat vehetünk fel? pl. Cyberpunk 2077, Nier: Automata
        // ilyenkor használhatunk listákat, amik dinamikusan tudnak nőni
        List<string> inventoryLista = new List<string>();
        inventoryLista.Add("Kard");
        inventoryLista.Add("Pajzs");
        inventoryLista.Add("Életerő ital");
        inventoryLista.Add("Mana ital");
        inventoryLista.Add("Tűz varázslat");
        inventoryLista.Add("Jég varázslat");
        // satöbbi... (a listát a copilot írta, nem én :D)

        // tömböt gyakorlatban RGB színtárolsánál használunk (8bit per channel, 0-255), mert fix méretű
        // listát gyakorlatban pl. user inputnál használunk, mert nem tudjuk előre, hány elemet fogunk kapni

    }
}
