namespace foodLib;
//class, that acts like a list except for special "contain method"
/*
    contains should return true if asked for "käse" and the list contains "mozzarella" or "gouda", and in reverse
    more rules to come
*/
    internal class FoodList : List<string>
    {   
        public FoodList(List<string> sl) : base(sl)
        {
        }
       
        public new bool Contains(string element)
        {
                switch(element)
                {
                    case "zwiebeln":
                        return base.Contains("zwiebel");
                    case "käse":
                    case "gouda":
                    case "mozarella":
                        return cheese();
                    default:
                        return base.Contains(element);
                }
        }

        private bool cheese(){
            if(base.Contains("käse")||base.Contains("gouda")||base.Contains("mozarella"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
