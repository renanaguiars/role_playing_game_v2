namespace RPG
{
    internal class Hero : Entity
    {
        private string weapon;
        public Inventory inventory = new();


        public Hero(string name, string weapon, Inventory inventory)
        {
            setLevel(1);
            SetName(name);
            SetWeapon(weapon);
            SetHp(1500);
            SetStamina(1500);
            SetIsAlive(true);
            setCharisma(150);
            setKnowledge(150);
            setStrength(150);
        }

        public void showSkills()
        {
            Console.WriteLine("======================");
            Console.WriteLine("NIVEL: " + getLevel());
            Console.WriteLine("SABEDORIA: " + getKnowledge());
            Console.WriteLine("CARISMA: " + getCharisma());
            Console.WriteLine("FORÇA: " + getStrength());
            Console.WriteLine("======================");
        }

        public void showStatus()
        {
            Console.WriteLine("======================");
            Console.WriteLine("HERÓI: " + GetName());
            Console.WriteLine("ARMA: " + GetWeapon());
            Console.WriteLine("VIDA: " + GetHp());
            Console.WriteLine("ENERGIA: " + GetStamina());
            Console.WriteLine("VIVO? " + GetIsAlive());
            Console.WriteLine("======================");
        }

        public void SetWeapon(string weapon)
        {
            this.weapon = weapon;
        }

        public string GetWeapon()
        {
            return weapon;
        }

        public void showInventory()
        {
            Console.WriteLine("-+-+-+- MEU INVENTÁRIO -+-+-+-");
            Console.WriteLine();
            Console.WriteLine("POÇÃO: " + inventory.GetPotion() + " unidade(s)");
            Console.WriteLine("FRUTA: " + inventory.GetFruit() + " unidade(s)");
            Console.WriteLine("ITEM: " + inventory.GetItem() + " unidade(s)");
            Console.WriteLine("BITCOIN: " + inventory.GetBitcoin() + " bitcoin(s)");
            Console.WriteLine();
            Console.WriteLine("-+-+-+--+-+-+--+-+-+--+-+-+--+-");
        }

        public void drinkPotion()
        {
            int hp = GetHp();
            int increaseHp = hp + 400;
            SetHp(increaseHp);
            int pot = inventory.GetPotion();
            pot--;
            inventory.SetPotion(pot);
        }

        public void eatFruit()
        {
            int fruit = inventory.GetFruit();
            int stamina = GetStamina();
            int increaseStamina = stamina + 250;
            SetStamina(increaseStamina);
            fruit--;
            inventory.SetFruit(fruit);
        }

        public void gameIntro()
        {
            Console.WriteLine(GetName() + " é um viajante. Ele mata monstros à pedido do Rei de Lisarb. ");
            Console.WriteLine("Em troca de deixar a terra segura, o Rei lhe paga em ouro. O que é seu ganha-pão.");
            Console.WriteLine("Certo dia, lá estava ele andando pelo bosque de Lisarb, caçando...");
            Console.WriteLine("Quando de repente, nosso herói se viu numa encruzilhada. O caminho se dividiu em dois.");
            Console.WriteLine("O caminho da esquerda e o caminho da direita.");
        }

        public void choosePath()
        {
            Console.WriteLine("=> Para onde o herói deve ir? ");
            Console.WriteLine();
            Console.WriteLine("[1] - Esquerda ");
            Console.WriteLine("[2] - Direita ");
            Console.WriteLine("[3] - Abrir Inventário ");
            Console.WriteLine("[0] - Sair do jogo ");
        }

        public void fightOptions()
        {
            Console.WriteLine("Um inimigo está a sua frente. O que fazer?");
            Console.WriteLine();
            Console.WriteLine("[1] - Lutar");
            Console.WriteLine("[2] - Fugir");
            Console.WriteLine("[3] - Abrir Inventário");
            Console.WriteLine("[0] - Sair do jogo");
        }

    }
}