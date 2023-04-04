using System;
using System.Timers;

namespace RPG
{
    internal class RPG
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            Inventory inventario = new Inventory();
            int opcao = 1000;

            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            Console.WriteLine("O Infortúnio dos Bravos - RPG");
            pulaLinha();
            Console.WriteLine("[1] - Jogar");
            Console.WriteLine("[2] - Instruções");
            Console.WriteLine("[0] - Sair do Jogo");
            pulaLinha();
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            pulaLinha();
            Console.Write("Resposta: ");
            int firstOp = int.Parse(Console.ReadLine());
            if (firstOp == 2)
            {
                Console.Clear();
                Console.WriteLine("Carregando...");
                Delay(5);
                Console.Clear();
                Console.WriteLine("Você é um herói da antiga Idade Média. Como qualquer RPG clássico, você iniciará no");
                Console.WriteLine("nível 1 e irá subindo conforme seu progresso no jogo. Se falar com civis, você");
                Console.WriteLine("ganhará pontos de carisma. Se matar monstros, ganha pontos de força. E por fim, ");
                Console.WriteLine("se você ler livros, ganha pontos de sabedoria. Existem itens escondidos no jogo");
                Console.WriteLine("que lhe darão pontos extras caso você seja bom explorador e os encontre.");
                Console.WriteLine("E aí, preparado para esta aventura?");
                pulaLinha();
                Console.WriteLine("[1] - Jogar");
                pulaLinha();
                Console.Write("Resposta: ");
                firstOp = int.Parse(Console.ReadLine());
                while (firstOp != 1)
                {
                    firstOp = int.Parse(Console.ReadLine());
                }
                Console.Clear();
            }
            if (firstOp == 1)
            {
                Console.Clear();
                Console.WriteLine("Jogo inicializando...");
                Delay(5);
                Console.Clear();
                Console.Write("=> Digite o nome do herói: ");
                string nomeHeroi = Console.ReadLine();

                Console.Write("=> Qual arma ele utilizará? ");
                string armaHeroi = Console.ReadLine();
                
                Console.Clear();

                Hero heroi = new Hero(nomeHeroi, armaHeroi, inventario);
                heroi.SetName(nomeHeroi);
                heroi.SetWeapon(armaHeroi);

                pulaLinha();

                heroi.showStatus();
                pulaLinha();
                heroi.showSkills();

                pulaLinha();

                Console.WriteLine("Floresta de Lisarb, 1822");
                
                pulaLinha();

                heroi.gameIntro();

                pulaLinha();

                heroi.choosePath();

                pulaLinha();

                Console.Write("Resposta: ");
                opcao = int.Parse(Console.ReadLine());

                while (opcao < 0 || opcao > 3)
                {
                    Console.Clear();
                    Console.WriteLine("DIGITE UMA OPÇÃO VÁLIDA!");

                    pulaLinha();

                    heroi.choosePath();

                    pulaLinha();

                    Console.Write("Resposta: ");
                    opcao = int.Parse(Console.ReadLine());

                }

                if (opcao == 1)
                {
                    Enemy inimigo = new Enemy("Hidra");

                    Console.Clear();

                    Console.WriteLine("Nosso herói pegou o caminho da ESQUERDA...");
                    
                    pulaLinha();

                    Console.WriteLine("Eis que " + nomeHeroi + " avista uma cachoeira e percebe um estranho vulto vindo da mesma.");
                    Console.WriteLine("Quando de repente, uma criatura emerge das profundezas da cachoeira.");
                    pulaLinha();

                    Console.WriteLine(inimigo.GetName() + ": - Você não é bem vindo aqui. Vou te matar!");
                    pulaLinha();

                    inimigo.getEnemyStatus();
                    pulaLinha();

                    heroi.fightOptions();
                    pulaLinha();

                    Console.Write("Resposta: ");
                    int act = int.Parse(Console.ReadLine());

                    Console.Clear();

                    int vidaHeroi = heroi.GetHp();
                    int staminaHeroi = heroi.GetStamina();
                    int vidaInimigo = inimigo.GetHp();
                    int staminaInimigo = inimigo.GetStamina();
                    int danoDoInimigo, danoDoHeroi;

                    if (act == 1)
                    {
                        pulaLinha();
                        Console.WriteLine("*** Combate INICIADO ***");
                        do
                        {
                            pulaLinha();
                            heroi.showStatus();
                            pulaLinha();
                            inimigo.getEnemyStatus();
                            pulaLinha();
                            Console.WriteLine("Aguardando movimento de combate...");
                            Delay(10); // 10seg
                            Console.Clear();
                            danoDoInimigo = inimigo.attackEntity();
                            vidaHeroi -= danoDoInimigo;
                            heroi.SetHp(vidaHeroi);

                            if (vidaHeroi <= 0 || staminaHeroi <= 0)
                            {
                                //Console.Clear();
                                heroi.SetIsAlive(false);
                                heroi.SetHp(0);
                                heroi.SetStamina(0);
                                pulaLinha();
                                heroi.showStatus();
                                pulaLinha();
                                inimigo.getEnemyStatus();
                                pulaLinha();
                                Console.WriteLine(inimigo.GetName() + " venceu o combate.");
                                Console.WriteLine("Você MORREU.");
                                Console.WriteLine("Fim de jogo.");
                                break;
                            }

                            pulaLinha();
                            Console.WriteLine("Aguardando movimento de combate...");
                            Delay(10); // 10seg
                            Console.Clear();
                            heroi.showStatus();
                            inimigo.getEnemyStatus();
                            danoDoHeroi = heroi.attackEntity();
                            vidaInimigo -= danoDoHeroi;
                            inimigo.SetHp(vidaInimigo);

                            if (vidaInimigo <= 0 || staminaInimigo <= 0)
                            {
                                inimigo.SetIsAlive(false);
                                inimigo.SetHp(0);
                                inimigo.SetStamina(0);
                                pulaLinha();
                                heroi.showStatus();
                                pulaLinha();
                                inimigo.getEnemyStatus();
                                pulaLinha();
                                Console.WriteLine(nomeHeroi + " venceu o combate.");
                                Console.WriteLine("Você ganhou +100 pts de FORÇA.");
                                Console.WriteLine("Você subiu de nível!");
                                int increaseStrength = heroi.getStrength();
                                increaseStrength += 100;
                                heroi.setStrength(increaseStrength);
                                Console.WriteLine("O inimigo MORREU.");
                                Delay(10);
                                pulaLinha();
                                heroi.showSkills();
                                break;
                            }

                        } while (vidaInimigo > 0 || vidaHeroi > 0);

                    }
                    else if (act == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("A opção escolhida foi: Fugir");
                        heroi.SetHp(0);
                        heroi.SetStamina(0);
                        heroi.SetIsAlive(false);
                        
                        Console.Clear();
                       
                        Console.WriteLine("Você correu e se escondeu atrás das pedras, próximo a cachoeira.");
                        Console.WriteLine("Alguns segundos se passaram, porém o inimigo te viu e te matou.");
                        Console.WriteLine("Foi a escolha errada.");
                        Console.WriteLine("Fim de jogo. Você MORREU. #RIP");
                        heroi.showStatus();
                    }
                    else if (act == 3)
                    {
                        Console.Clear();
                        heroi.showInventory();
                        heroi.showStatus();
                    }
                    else
                    {
                        Console.WriteLine("Fim de jogo.");
                    }

                }
                else if (opcao == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Nosso herói pegou o caminho da DIREITA...");

                    pulaLinha();

                    Console.WriteLine("Após caminhar por mais 30 minutos, ele avistou um caminho de pedras que terminava num enorme castelo.");
                    Console.WriteLine("Nosso herói, sorrateiramente, entra no castelo, pela porta dos fundos...");
                    Console.WriteLine(nomeHeroi + " acredita que o castelo está vazio, pois não encontrou ninguém por lá.");
                    Console.WriteLine("No entanto, pensa que pode ser bom procurar por itens valiosos/úteis.");

                    pulaLinha();

                    Console.WriteLine("O que nosso herói deve fazer ?");

                    pulaLinha();

                    Console.WriteLine("[1] - Procurar itens valiosos");
                    Console.WriteLine("[2] - Dar o fora antes que alguém apareça");
                    Console.WriteLine("[0] - Sair do jogo");

                    pulaLinha();

                    Console.Write("Resposta: ");
                    int res = int.Parse(Console.ReadLine());
                    switch (res)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(nomeHeroi + " então, ao procurar itens, se depara com um grande baú.");
                            Console.WriteLine("Ao abrir o baú, encontra um relógio antigo de ouro e uma poção de HP.");
                            pulaLinha();
                            Console.WriteLine("Cheque seu inventário para saber sua qtd de itens atual:");
                            pulaLinha();
                            Console.WriteLine("---------- MENU ----------");
                            pulaLinha();
                            Console.WriteLine("[1] - Abrir Inventário");
                            Console.WriteLine("[0] - Sair do Jogo");
                            pulaLinha();
                            Console.WriteLine("--------------------------");
                            pulaLinha();
                            Console.Write("Resposta: ");
                            int resp = int.Parse(Console.ReadLine());
                           
                            while (resp > 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Digite uma resposta válida: ");
                                pulaLinha();
                                Console.WriteLine("---------- MENU ----------");
                                pulaLinha();
                                Console.WriteLine("[1] - Abrir Inventário");
                                Console.WriteLine("[0] - Sair do Jogo");
                                pulaLinha();
                                Console.WriteLine("--------------------------");
                                pulaLinha();
                                Console.Write("Resposta: ");
                                resp = int.Parse(Console.ReadLine());
                            }

                            if (resp == 1)
                            {
                                Console.Clear();
                                pulaLinha();
                                heroi.showInventory();
                                pulaLinha();

                                Console.WriteLine("---------- MENU ----------");
                                pulaLinha();
                                Console.WriteLine("[1] - Fechar Inventário");
                                Console.WriteLine("[0] - Sair do Jogo");
                                pulaLinha();
                                Console.WriteLine("--------------------------");

                                pulaLinha();
                                Console.Write("Resposta: ");
                                resp = int.Parse(Console.ReadLine());
                                if (resp == 1)
                                {
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Fim de jogo.");
                                }


                            }
                            else if (resp == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Fim de jogo.");
                            }

                            int pocoes = heroi.inventory.GetPotion();
                            int item = heroi.inventory.GetItem();
                            item++;
                            pocoes++;
                            
                            heroi.inventory.SetPotion(pocoes);
                            heroi.inventory.SetItem(item);

                            pulaLinha();
                            Console.WriteLine("Itens adicionados ao inventário com sucesso. ");
                            break;

                        case 2:
                            Console.WriteLine("Você fugiu do castelo e voltou para a floresta.");
                            break;

                        case 0:
                            Console.WriteLine("É game over papai. Kitou.");
                            break;

                    }
                }
                else if (opcao == 3)
                {
                    Console.Clear();
                    heroi.showInventory();

                    pulaLinha();

                    Console.WriteLine("[1] - Tomar poção de cura (Cura 400 de HP) ");
                    Console.WriteLine("[2] - Comer uma fruta (Recupera 250 de Stamina) ");
                    Console.WriteLine("[0] - Sair do Inventário ");

                    pulaLinha();

                    Console.Write("Resposta: ");
                    opcao = int.Parse(Console.ReadLine());

                    if (opcao == 1)
                    {
                        Console.Clear();
                        heroi.drinkPotion();
                        heroi.showStatus();
                        pulaLinha();
                        heroi.showInventory();
                    }
                    else if (opcao == 2)
                    {
                        Console.Clear();
                        heroi.eatFruit();
                        heroi.showStatus();
                        pulaLinha();
                        heroi.showInventory();
                    }
                    else if(opcao == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Saiu do Inventário");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("DIGITE UMA OPÇÃO VÁLIDA!");
                        
                        heroi.showInventory();

                        pulaLinha();

                        Console.WriteLine("[1] - Tomar poção de cura (Cura 400 de HP) ");
                        Console.WriteLine("[2] - Comer uma fruta (Recupera 250 de Stamina) ");
                        Console.WriteLine("[0] - Sair do Inventário ");

                        pulaLinha();

                        Console.Write("Resposta: ");
                        opcao = int.Parse(Console.ReadLine());

                    }
                }
                else if (opcao == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Fim de jogo.");
                }
            }

        }

        static void pulaLinha()
        {
            Console.WriteLine();
        }

        public static void Delay(double tempo)
        {
            // 0.300
            // 0.100 = 1 seg

            var t = Task.Run(async
                delegate
            {
                await Task.Delay(TimeSpan.FromSeconds(tempo));
                return 42;
            });
            t.Wait();

        }
    }
}
