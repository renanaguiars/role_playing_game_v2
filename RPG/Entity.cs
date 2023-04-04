namespace RPG
{
    internal class Entity
    {
        private string name;
        private int hp;
        private int level;
        private int strength;
        private int knowledge;
        private int charisma;
        private int stamina;
        private bool isAlive;

        public int getKnowledge()
        {
            return knowledge;
        }

        public void setKnowledge(int knowledge)
        {
            this.knowledge = knowledge;
        }

        public int getCharisma()
        {
            return charisma;
        }

        public void setCharisma(int charisma)
        {
            this.charisma = charisma;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetHp()
        {
            return hp;
        }

        public void SetHp(int hp)
        {
            this.hp = hp;
        }

        public int GetStamina()
        {
            return stamina;
        }

        public void SetIsAlive(bool isAlive)
        {
            this.isAlive = isAlive;
        }

        public bool GetIsAlive()
        {
            return isAlive;
        }

        public void SetStamina(int stamina)
        {
            this.stamina = stamina;
        }

        public int getStrength()
        {
            return strength;
        }

        public void setStrength(int strength)
        {
            this.strength = strength;
        }

        public int getLevel()
        {
            return level;
        }

        public void setLevel(int level)
        {
            this.level = level;
        }

        public int attackEntity()
        {
            Random rand = new Random();

            int stm = GetStamina();
            int damage = rand.Next(0, 6);
            int reduceStm = damage * 40;
            if (damage == 0)
            {
                reduceStm = 40;
                Console.WriteLine();
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.WriteLine("O " + name + " ERROU o golpe.");
                Console.WriteLine("Força do golpe [0-5]: " + damage);
                Console.WriteLine("Dano aplicado: " + damage * getStrength());
                Console.WriteLine("Stamina gasta: " + reduceStm);
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                SetStamina(stm - reduceStm);
            }
            else if (damage > 0 && damage <= 2)
            {
                Console.WriteLine();
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.WriteLine("O " + name + " aplicou um golpe FRACO.");
                Console.WriteLine("Força do golpe [0-5]: " + damage);
                Console.WriteLine("Dano aplicado: " + damage * getStrength());
                Console.WriteLine("Stamina gasta: " + reduceStm);
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                SetStamina(stm - reduceStm);
            }
            else if (damage > 2 && damage < 5)
            {
                Console.WriteLine();
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.WriteLine("O " + name + " aplicou um golpe FORTE.");
                Console.WriteLine("Força do golpe [0-5]: " + damage);
                Console.WriteLine("Dano aplicado: " + damage * getStrength());
                Console.WriteLine("Stamina gasta: " + reduceStm);
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                SetStamina(stm - reduceStm);
            }
            else if (damage == 5)
            {
                Console.WriteLine();
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.WriteLine("O " + name + " aplicou um golpe CRÍTICO.");
                Console.WriteLine("Força do golpe [0-5]: " + damage);
                Console.WriteLine("Dano aplicado: " + damage * getStrength());
                Console.WriteLine("Stamina gasta: " + reduceStm);
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                SetStamina(stm - reduceStm);
            }
            return damage * getStrength();
        }

    }
}
