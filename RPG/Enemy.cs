namespace RPG
{
    internal class Enemy : Entity
    {

        public Enemy(string name)
        {
            SetName(name);
            SetHp(500);
            SetStamina(500);
            SetIsAlive(true);
            setLevel(2);
            setStrength(100);
            setCharisma(0);
            setKnowledge(0);
        }

        public void getEnemyStatus()
        {
            Console.WriteLine("======================");
            Console.WriteLine("INIMIGO: " + GetName());
            Console.WriteLine("NIVEL: " + getLevel());
            Console.WriteLine("FORÇA: " + getStrength());
            Console.WriteLine("VIDA: " + GetHp());
            Console.WriteLine("ENERGIA: " + GetStamina());
            Console.WriteLine("VIVO? " + GetIsAlive());
            Console.WriteLine("======================");
        }

    }
}