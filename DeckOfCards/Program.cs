using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
// ReSharper disable All

namespace DeckOfCards {
    internal class Program {
        private static void Main(string[] args) {
            int numHands = 5;

            BlackJackGameAutomator automator = new BlackJackGameAutomator(numHands);
            automator.InitializeDeck();
            bool success = automator.DealInitial();
            if (!success) {
                Console.WriteLine("Error. Out of cards.");
            } else {
                Console.WriteLine("-- Initial --");
                automator.PrintHandsAndScore();
                List<int> blackjacks = automator.GetBlackJacks();
                if (blackjacks.Count > 0) {
                    Console.WriteLine("Blackjack at ");
                    foreach (int i in blackjacks) {
                        Console.WriteLine(i + ", ");
                    }

                    Console.WriteLine();
                }
                else {
                    success = automator.PlayAllHands();
                    if (!success) {
                        Console.WriteLine("Error. Out of cards.");
                    }
                    else {
                        Console.WriteLine("\n-- Completed Game --");
                        automator.PrintHandsAndScore();
                        List<int> winners = automator.GetWinners();
                        if (winners.Count > 0) {
                            Console.WriteLine("Winners: ");
                            foreach (int i in winners) {
                                Console.WriteLine(i + ", ");
                            }

                            Console.WriteLine();
                        }
                        else {
                            Console.WriteLine("Draw. All players have busted.");
                        }
                    }
                }
            }
        }
    }
}