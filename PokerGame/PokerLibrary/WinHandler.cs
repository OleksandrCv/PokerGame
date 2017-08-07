using System.Collections.Generic;

namespace PokerLibrary
{
    /// <summary>
    /// Abstact class for chain of responsibility pattern
    /// </summary>
    public abstract class WinHandler
    {
        protected WinHandler Successor;
        
        /// <summary>
        /// Set derived class that will process data next
        /// </summary>
        /// <param name="successor"></param>
        public void SetSuccessor(WinHandler successor)
        {
            this.Successor = successor;
        }

        /// <summary>
        /// Process request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public abstract List<string> HandleRequest(List<Player> request);
    }

    /// <summary>
    ///  Specific implementation for Flush combination
    /// </summary>
    public class FlushHandler : WinHandler
    {
        public override List<string> HandleRequest(List<Player> request)
        {
            var result = new List<string>();
                foreach (var item in request)
	            {
                    var isFlush = Helper.IsFlush(item);

                    if (isFlush)
                    {
                        result.Add(item.Name);
                    }
	            }

                if (result.Count == 0 && Successor != null) 
                {
                    return Successor.HandleRequest(request);
                }

            return result;
        }
    }

    /// <summary>
    /// Specific implementation of Three Of A Kind combination
    /// </summary>
    public class ThreeOfAKindHandler : WinHandler
    {
        private const int three = 3;

        public override List<string> HandleRequest(List<Player> request)
        {
            var result = new List<string>();
                foreach (var item in request)
	            {
                    var isTreeOfAKind = Helper.isCardsOfAKind(item, three);
                    if (isTreeOfAKind)
                    {
                        result.Add(item.Name);
                    }
	            }

                if (result.Count == 0 && Successor != null)
                {
                    return Successor.HandleRequest(request);
                }
            
            return result;
        }
    }

    /// <summary>
    /// Specific implementation of One Pair combination
    /// </summary>
    public class OnePairHandler : WinHandler
    {
        private const int onePair = 2;

        public override List<string> HandleRequest(List<Player> request)
        {
            var result = new List<string>();
                foreach (var item in request) 
                {
                    var isOnePair = Helper.isCardsOfAKind(item, onePair);
                    if (isOnePair) 
                    { 
                        result.Add(item.Name); 
                    }
                }
                
                if (result.Count == 0 && Successor != null)
                {
                    return Successor.HandleRequest(request);
                } 
            
            return result;
        }
    }

    /// <summary>
    /// Specific implementation of HighCard combination
    /// </summary>
    public class HighCardHandler : WinHandler
    {
        public override List<string> HandleRequest(List<Player> request)
        {
            var result = new List<string>();
            int hisghestCard = 0;
                foreach (var item in request) 
                {
                    var rank = Helper.GetHighestRank(item);

                    if (rank == hisghestCard)
                    {
                        result.Add(item.Name);
                    }
                    else if (rank > hisghestCard) 
                    {
                        hisghestCard = rank;
                        result.Clear();
                        result.Add(item.Name);
                    }
                }
            
            return result;
        }
    }
}

