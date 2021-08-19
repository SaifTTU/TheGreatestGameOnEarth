using Internal;
//this version implemented a placement function, as well as turn and observe. Modification to original source code by Tucker Hortman.
//this version includes an attack function and truck functionality
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class piece
    {
        public int Health = 1;
        public int Attack = 1;
        public int side = 0;
        
        public int Type;

        public  piece[] cargo = new piece[5];
        
        bool hasAttacked = false;

        /* Types:
         * 0 = Grunt    1,1
         * 1 = Grunt    1,4
         * 2 = Healer  2,2
         * 3 = Sniper  2,2
         * 4 = Truck   3,8
         * 5 = king    1,1
         */

        string Symbol;
        /*
         * Symbols:
         * G = Grunt
         * H = Healer
         * S = Sniper
         * T = Truck
         * q = queen
         * K = king
         */

        int xCord;
        int yCord;
        int ID;

        public piece(int type)
        {
            Random rand = new Random();
            this.ID = rand.Next(0,325);
            if(type == 1)
            {
                this.Symbol = "G";
                this.Health = 1;
                this.Attack = 1;
                this.Type = 1;
            }

            if(type == 2)
            {
                this.Symbol = "H";
                this.Health = 4;
                this.Attack = 1;
                this.Type = 2;
            }

            if(type == 3)
            {
                this.Symbol = "S";
                this.Health = 2;
                this.Attack = 2;
                this.Type = 3;
            }

            if(type == 4)
            {
                this.Symbol = "T";
                this.Health = 2;
                this.Attack = 2;
                this.Type = 4;
                piece[] carg = new piece[4];
            }

            if(type == 5)
            {
                this.Symbol = "q";
                this.Health = 8;
                this.Attack = 3;
                this.Type = 5;
            }

            if(type == 6)
            {
                this.Symbol = "K";
                this.Health = 1;
                this.Attack = 1;
                this.Type = 6;
            }
        }

        public int getID()
        {
            return this.ID;
        }
        public string getSymbol()
        {
            return this.Symbol;
        }

        public void setXCord(int x)
        {
            this.xCord = x;
        }

        public void setYCord(int y)
        {
            this.yCord = y;
        }

        public void setSide(int s){
            this.side = s;
        }
        public int getSide(){
            return this.side;
        }

        public int getXCord()
        {
            return this.xCord;
        }

        public int getYCord()
        {
            return this.yCord;
        }

        public bool getHasAttacked()
        {
            return this.hasAttacked;
        }
        public void setHasAttacked(bool ifAttacked)
        {
            this.hasAttacked = ifAttacked;
        }

        public void resetAttacked()
        {
            this.hasAttacked = false;
        }
        
         public void getAttacks(int x, int y, Tile[,] map)
        {
            int side = map[y,x].getPiece().getSide();// side = aliance
            Console.WriteLine("Piece of type "+ map[y,x].getPiece().getSymbol() + " and of side "+ side +" wishes to attack.");
            int adjacentSide;
            //tracks tiles able to be attacked
            int[] choice = {0,0,0,0,0,0,0,0,0,0};
            string[] choiceCoordinatesDisplay = new string[10];
            //Up and Left
            if(map[y-1,x-1] != null) //switched y and x because of how its read in the matrix
            {
                //adjacentSide = map[y - 1, x - 1].getPiece().side;
                if (map[y - 1, x - 1].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y - 1, x - 1].getPiece().getSymbol() + " unit at (" + (x-1) + " , " + (y-1) + ")");
                    choice[1] = 1;
                    choiceCoordinatesDisplay[1] = "("+(x-1)+","+(y-1)+")";
                }
            }
            //Forward
            if (map[y - 1 , x] != null)
            {
                //adjacentSide = map[y-1, x].getPiece().side;
                if (map[y - 1 , x].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y - 1 , x].getPiece().getSymbol() + " unit at (" + x + " , " + (y-1) + ")");
                    choice[2] = 1;
                    choiceCoordinatesDisplay[2] = "("+(x)+","+(y-1)+")";
                }
            }
            //Up and Right
            if (map[y - 1, x + 1] != null)
            {
                //adjacentSide = map[x + 1, y - 1].getPiece().side;
                if (map[y - 1, x + 1].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y - 1, x + 1].getPiece().getSymbol() + " unit at (" + (x+1) + " , " + (y-1) + ")");
                    choice[3] = 1;
                    choiceCoordinatesDisplay[3] = "("+(x+1)+","+(y-1)+")";
                }
            }
            //Left
            if (map[y, x - 1 ] != null)
            {
                //adjacentSide = map[y, x - 1].getPiece().side;
                if (map[ y, x - 1 ].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y, x - 1].getPiece().getSymbol() + " unit at (" + (x-1) + " , " + y + ")");
                    choice[4] = 1;
                    choiceCoordinatesDisplay[4] = "("+(x-1)+","+(y)+")";
                }
            }
            //Right
            if (map[y, x+1 ] != null)
            {
                //adjacentSide = map[x + 1, y].getPiece().side;
                if (map[y, x + 1 ].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y, x + 1].getPiece().getSymbol() + " unit at (" + (x+1) + " , " + y + ")");
                    choice[6] = 1;
                    choiceCoordinatesDisplay[6] = "("+(x+1)+","+(y)+")";
                }
            }
            //Down and Left
            if (map[y + 1, x - 1] != null)
            {
                //adjacentSide = map[y + 1, x - 1].getPiece().side;
                if (map[y + 1, x - 1].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y + 1, x - 1].getPiece().getSymbol() + " unit at (" + (x-1) + " , " + (y+1) + ")");
                    choice[7] = 1;
                    choiceCoordinatesDisplay[7] = "("+(x-1)+","+(y+1)+")";
                }
            }
            //Down
            if (map[y + 1, x] != null)
            {
                //adjacentSide = map[x, y + 1].getPiece().side;
                if (map[y+1 , x].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y + 1, x].getPiece().getSymbol() + " unit at (" + x + " , " + (y+1) + ")");
                    choice[8] = 1;
                    choiceCoordinatesDisplay[8] = "("+(x)+","+(y+1)+")";

                }
            }
            //Down and Right
            if (map[y + 1, x + 1] != null)
            {
                //adjacentSide = map[x + 1, y + 1].getPiece().side;
                if (map[y + 1, x + 1].getPiece() != null)
                {
                    Console.WriteLine("You can attack the " + map[y + 1, x + 1].getPiece().getSymbol() + " unit at (" + (x+1) + " , " + (y+1) + ")");
                    choice[9] = 1;
                    choiceCoordinatesDisplay[9] = "("+(x+1)+","+(y+1)+")";
                }
            }

            
            Console.WriteLine("Do you wish to attack?: y/n");
            string input = Console.ReadLine();
            if(input=="y"||input=="Y")
            {
                
                Console.WriteLine("What tile?");
                for (int i = 0; i < 10; i++)
                {
                    if(choice[i] == 1)
                    {
                        Console.WriteLine(i+". " + choiceCoordinatesDisplay[i]);
                    }
                }
                int trigger;
                trigger = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Chose to attack "+ choiceCoordinatesDisplay[trigger]);
                attack(trigger, map);
            }
            

        }

        public void attack(int direction, Tile[,] map)
        {
            Console.WriteLine("Attacking the "+ direction);
            int test = direction;
            //Actually does the attacking
            switch (direction)
            {
                case 1:
                    Console.WriteLine("Attacking the :" + map[this.xCord - 1, this.yCord - 1].getPiece().getSymbol());
                    map[this.xCord - 1, this.yCord - 1].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                case 2:
                    Console.WriteLine("Attacking the :" + map[this.xCord , this.yCord - 1].getPiece().getSymbol());
                    map[this.xCord , this.yCord - 1].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                case 3:
                    Console.WriteLine("Attacking the :" + map[this.xCord + 1, this.yCord - 1].getPiece().getSymbol());
                    map[this.xCord + 1, this.yCord - 1].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                case 4:
                    Console.WriteLine("Attacking the :" + map[this.xCord - 1, this.yCord ].getPiece().getSymbol());
                    map[this.xCord - 1, this.yCord ].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                case 6:
                    Console.WriteLine("Attacking the :" + map[this.xCord +1, this.yCord ].getPiece().getSymbol());
                    map[this.xCord + 1, this.yCord ].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                case 7:
                    Console.WriteLine("Attacking the :" + map[this.xCord - 1, this.yCord + 1].getPiece().getSymbol());
                    map[this.xCord - 1, this.yCord + 1].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                case 8:
                    Console.WriteLine("Attacking the :" + map[this.xCord , this.yCord + 1].getPiece().getSymbol());
                    map[this.xCord , this.yCord + 1].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                case 9:
                    Console.WriteLine("Attacking the :" + map[this.xCord + 1, this.yCord + 1].getPiece().getSymbol());
                    map[this.xCord + 1, this.yCord + 1].getPiece().Health -= this.Attack;
                    Console.WriteLine("You delt " + this.Attack + " damage!");
                    break;
                default:
                    Console.WriteLine("Error in attack()");
                    break;
            }
        }
        public void addToTruck(piece piece1, Tile[,] map)
        {
            Console.WriteLine("What piece would you like to put in the truck?:");
            //tracks tiles able to be attacked
            int[] choice = new int[10];
            //Up and Left
            if (map[this.xCord - 1, this.yCord - 1] != null)
            {
                if (map[this.xCord - 1, this.yCord - 1].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord - 1, this.yCord - 1].getPiece().getSymbol() + " at (" + (this.xCord - 1) + " , " + (this.yCord - 1) + ")");
                    choice[1] = 1;
                }
            }
            //Forward
            if (map[this.xCord, this.yCord - 1] != null)
            {
                if (map[this.xCord, this.yCord - 1].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord, this.yCord - 1].getPiece().getSymbol() + " at (" + this.xCord + " , " + (this.yCord - 1) + ")");
                    choice[2] = 1;
                }
            }
            //Up and Right
            if (map[this.xCord + 1, this.yCord - 1] != null)
            {
                if (map[this.xCord + 1, this.yCord - 1].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord + 1, this.yCord - 1].getPiece().getSymbol() + " at (" + (this.xCord + 1) + " , " + (this.yCord - 1) + ")");
                    choice[3] = 1;
                }
            }
            //Left
            if (map[this.xCord - 1, this.yCord] != null)
            {
                if (map[this.xCord - 1, this.yCord].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord - 1, this.yCord].getPiece().getSymbol() + " at (" + (this.xCord - 1) + " , " + this.yCord + ")");
                    choice[4] = 1;
                }
            }
            //Right
            if (map[this.xCord + 1, this.yCord] != null)
            {
                if (map[this.xCord + 1, this.yCord].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord + 1, this.yCord].getPiece().getSymbol() + " at (" + (this.xCord + 1) + " , " + this.yCord + ")");
                    choice[6] = 1;
                }
            }
            //Down and Left
            if (map[this.xCord - 1, this.yCord + 1] != null)
            {
                if (map[this.xCord - 1, this.yCord + 1].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord - 1, this.yCord + 1].getPiece().getSymbol() + " at (" + (this.xCord - 1) + " , " + (this.yCord + 1) + ")");
                    choice[7] = 1;
                }
            }
            //Down
            if (map[this.xCord, this.yCord + 1] != null)
            {
                if (map[this.xCord, this.yCord + 1].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord, this.yCord + 1].getPiece().getSymbol() + " at (" + this.xCord + " , " + (this.yCord + 1) + ")");
                    choice[8] = 1;
                }
            }
            //Down and Right
            if (map[this.xCord + 1, this.yCord + 1] != null)
            {
                if (map[this.xCord + 1, this.yCord + 1].getPiece() != null)
                {
                    Console.WriteLine("You can add the " + map[this.xCord + 1, this.yCord + 1].getPiece().getSymbol() + " at (" + (this.xCord + 1) + " , " + (this.yCord + 1) + ")");
                    choice[9] = 1;
                }
            }


            Console.WriteLine("Do you wish to add a unit to the truck?: y/n");

            if (Console.ReadLine().Equals("y"))
            {
                int trigger;
                Console.WriteLine("What unit?");
                for (int i = 0; i < 10; i++)
                {
                    if (choice[i] == 1)
                    {
                        Console.WriteLine(i);
                    }
                }
                trigger = Convert.ToInt32(Console.ReadLine());

                for(int i = 0; i <5; i++)
                {
                    if(this.cargo[i] == null)
                    {
                        switch (trigger)
                        {
                            case 1:
                                cargo[i] = map[this.xCord - 1, this.yCord - 1].getPiece();
                                //map[this.xCord - 1, this.yCord - 1].getPiece() = null;
                                break;
                            case 2:
                                cargo[i] = map[this.xCord , this.yCord - 1].getPiece();
                                break;
                            case 3:
                                cargo[i] = map[this.xCord + 1 , this.yCord - 1].getPiece();
                                break;
                            case 4:
                                cargo[i] = map[this.xCord-1, this.yCord].getPiece();
                                break;
                            case 6:
                                cargo[i] = map[this.xCord+1, this.yCord ].getPiece();
                                break;
                            case 7:
                                cargo[i] = map[this.xCord-1, this.yCord + 1].getPiece();
                                break;
                            case 8:
                                cargo[i] = map[this.xCord, this.yCord +1].getPiece();
                                break;
                            case 9:
                                cargo[i] = map[this.xCord + 1, this.yCord + 1].getPiece();
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                        break;   
                    }
                }
            }


        }
    }

    class Map
    {
        public static void displayMap(Tile[,] map)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(map[i, j].getElevation() + " ");
                }
                Console.WriteLine("");
            }
        }

        public static void displayMines(Tile[,] map)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(map[i, j].hasMine() + " ");
                }
                Console.WriteLine("");
            }
        }

        public static void dispMinesAsBool(Tile[,] map)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(map[i,j].hasMine() == true)
                    {
                        Console.Write(1 + " ");

                    }
                    else
                    {
                        Console.Write(0 + " ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public static void dispPieceMap(Tile[,] map)
        {
            for(int i = 0; i <9; i++)
            {
                for( int j = 0; j < 9; j++)
                {
                    if (map[i, j].getPiece() == null)
                    {
                        Console.Write(0 + " ");
                    }
                    else
                    {
                        Console.Write(map[i, j].getPiece().getSymbol() + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void populateMap(Random rand, Tile[,] map)
        {

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    map[i, j] = new Tile(rand.Next(-2, 2));
                }
            }
        }
        public static void placePawns(Tile[,] map)
        {
            
            for (int i = 0; i < 9; i++)
            {
                map[2, i].setPiece(new piece(4));
                map[2, i].getPiece().setXCord(i);
                map[2, i].getPiece().setYCord(2);
                

                map[7, i].setPiece(new piece(4));
                map[7, i].getPiece().setXCord(i);
                map[7, i].getPiece().setYCord(7);

                //added these
                map[2, i].getPiece().setSide(1);
                map[7, i].getPiece().setSide(2);
            }
        }
        public static void dropMines(Random rand, Tile[,] map)
        {
            for(int i = 4; i < 6; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(rand.Next(0,10) > 8)
                    {
                        map[i, j].setMine(true);
                    }
                }
            }
        }
            
            public static void displayBoth(Tile[,] map)
            {
                 for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                if (map[i, j].getPiece() == null)
                                {
                                    Console.Write(0 + " ");
                                }
                                else
                                {
                                    Console.Write(map[i, j].getPiece().getSymbol() + " ");
                                }
                            }
                            Console.Write("      |      ");
                            for (int j = 0; j < 9; j++)
                            {
                                if( map[i, j].getElevation() >= 0 ) //to adjust the spacing
                                    Console.Write(" ");
                                    
                                Console.Write(map[i, j].getElevation() + " ");

                                Console.Write(" ");
                            }
                            
                            Console.Write("  |      ");
                            Console.WriteLine("");
                 }
            
        }
        public static void calculateDistance(int currentTile, int prospectiveTile){
                        int distance;
                        if(prospectiveTile<currentTile){
                            distance = (currentTile - prospectiveTile);
                            Console.WriteLine(" is bellow the current tile by " + distance + " squares. " );
                        }
                        if(prospectiveTile==currentTile){
                            distance = 0;
                            Console.WriteLine(" is on the same level is the current tile and as such, it would only cost 1 movement to move this unit." );
                        }
                        if(prospectiveTile>currentTile){
                            distance = (prospectiveTile - currentTile);
                            Console.WriteLine(" is above the current unity by "+distance+" squares, that means it would take, " + distance + " extra steps for it to move to this piece" );
                        }
                        
                    }
        public static int ObserveUnit(int x, int y, Tile[,] map, player currentPlayer){
            try{
                 if (map[y, x].getPiece() != null){
                    Console.WriteLine("There exists a piece on this tile of the type : "+ map[y, x].getPiece().getSymbol());
                    Console.WriteLine("Its health is : "+ map[y, x].getPiece().Health);
                    Console.WriteLine("Its attack is : "+ map[y, x].getPiece().Attack);

                    int side = map[y,x].getPiece().side;
                    //Console.WriteLine("Its on player "+side+"'s side.");
                    bool[,] surroundingEnemies = new bool[3,3];
                    if(map[y,x].getPiece().getHasAttacked() == false)
                        surroundingEnemies = checkForEnemies(side, x, y, map);

                    Console.WriteLine("Do you wish to move this unit? Y/N? ");
                    string input = Console.ReadLine();
                    if(input=="y"){
                        int cost = 1;
                        Console.WriteLine("Which direction? W/A/S/D? ");
                        input = Console.ReadLine();
                        if(input=="w" || input=="W"){
                            map[y-1,x].setPiece(map[y,x].getPiece());
                            map[y,x].setPiece(null);
                            //whole lotta error handling has to occur on this line
                            //such as if that move is valid,
                            //if there is already a piece there
                            //if this unit is allowed to go to that unit etc. 
                            Console.Write("Piece has been moved up,");
                            cost = (Math.Abs(map[y,x].getElevation() - map[y-1,x].getElevation())+1);
                        }
                        if(input=="s" || input=="S"){
                            map[y+1,x].setPiece(map[y,x].getPiece());
                            map[y,x].setPiece(null);
                            Console.Write("Piece has been moved down,");
                            cost = (Math.Abs(map[y,x].getElevation() - map[y-1,x].getElevation())+1);
                            Console.Write("It Costed: "+ (cost));
                        }
                        if(input=="a" || input=="A"){
                            map[y,x-1].setPiece(map[y,x].getPiece());
                            map[y,x].setPiece(null);
                            Console.Write("Piece has been moved left,");
                            cost = (Math.Abs(map[y,x].getElevation() - map[y,x-1].getElevation())+1);
                        }
                        if(input=="d" || input=="d"){
                            map[y,x+1].setPiece(map[y,x].getPiece());
                            map[y,x].setPiece(null);
                            Console.Write("Piece has been moved right,");
                            cost = (Math.Abs(map[y,x].getElevation() - map[y,x+1].getElevation())+1);
                        }
                        Console.Write(" new map: \n");
                        dispPieceMap(map);
                        //displayBoth(map);
                        Console.Write("It Costed: "+ (cost)+". \n");
                        //currentPlayer.setGold(currentPlayer.gold-cost); //I know I'm modifying an instance object and then returning an int instead of the full object
                        //in the big game, this will not be an issue, as most variables are ready like global variables in a script
                        //either that or we can make the two players static (but that would limit the number of players to only 2 permanently
                        //currentPlayer.displayGold();

                        if(map[y,x].getPiece().getHasAttacked() == false) //calls this again
                            surroundingEnemies = checkForEnemies(side, x, y, map);

                        return cost;
                    }
                 }
             }
             catch(Exception){
                
             }
             return 0;
        }
        public static void checkAvailable(Tile[,] map, int i, int j){
            Console.WriteLine("Checking if this is a valid space...");
        }
        public static int listOptions(Tile[,] map, int x, int y){
             int chosen = 0;//remains 0 if the user doesnt pick anything
             if(map[y,x].getPiece() != null){
                Console.WriteLine("There is already a unit on this position");
             }
             if(map[y,x].getPiece() == null){
                 Console.WriteLine("\n***AVAILABLE Units***");
                 Console.WriteLine("\n   Name : Cost ");
                 Console.WriteLine("1. Engineer : 1 cp"); 
                 Console.WriteLine("2. Grunt : 2 cp"); 
                 Console.WriteLine("3. Ranged : 3 cp"); 
                 Console.WriteLine("0. Cancel\n");
                 
                 Console.WriteLine("Do you want a description of any of these units? Y/N");
                 string toDescribe = Console.ReadLine();
                 if(toDescribe=="Y" || toDescribe=="y"){
                    Console.WriteLine("What unit do you want a description of? Type in the number and press enter.");
                    int option = Convert.ToInt32(Console.ReadLine());
                    describeUnit(option);
                 }
                 
                 Console.WriteLine("What unit would you like to purchase? Type in the number and press enter.");
                 chosen = Convert.ToInt32(Console.ReadLine());
                 
                 if(chosen!=0){
                 
                    Console.WriteLine("Are you sure? Y/N");
                    string input = Console.ReadLine();
                    if(input=="Y" || input=="y"){
                        
                        map[y,x].setPiece(new piece(chosen));
                        dispPieceMap(map);
                        Console.WriteLine("New unit of type "+chosen+" placed on tile("+x+","+y+")");
                    }
                 }
             }
             
             
             return chosen;
        }
        
        public static int getCost(int chosen){
                    switch (chosen)
                    {
                            case 1:
                                return 1;
                                break;
                    
                            case 2:
                                return 2;
                                break;
                    
                            case 3:
                                return 3;
                                break;
                    
                            default:
                                return 0;
                                break;
                    }
                        
        }
        
        public static void describeUnit(int o){
            switch (o)
                {
                    case 1:
                        Console.WriteLine("1. Engineer 3HP 2MOV 1ATK 2DEF 1RNG Cost : 2 cp");
                        Console.WriteLine("SPECIAL ABILITIES: ");
                        Console.WriteLine("BUILDS STUCTURES ");
                        Console.WriteLine("REPAIRS STRUCTURES +4 ");
                        Console.WriteLine("HEALS UNIT +3 ");
                        Console.WriteLine("HEALS AREA +2 ");
                        break;
            
                    case 2:
                        Console.WriteLine("2. Grunt 4HP 2MOV 3ATK 2DEF 1RNG Cost : 2 cp");
                        break;
            
                    case 3:
                        Console.WriteLine("3. Sniper 3HP 3MOV 5ATK 1DEF 5RNG Cost : 2 cp");
                        break;
            
                    default:
                        Console.WriteLine("Unit entered is invalid.");
                        break;
                }
        }
        
        public static void ObserveTile(int x, int y, Tile[,] map){
            if(map[x, y]!=null){
                Console.WriteLine("This piece, which exists on the point: ("+x+", "+y+")");
                Console.WriteLine("Is of the height: "+ map[y,x].getElevation());

                

                Console.Write("Its neighbors: ");

                bool[] possibleDirections = new bool[4];
                

                

                try
                {
                    if(map[y-1,x]!=null){
                        Console.Write("Up, ");
                        possibleDirections[0]=true;
                    }
                }
                catch(Exception){
                    possibleDirections[0]=false;
                }
                try
                {
                    if(map[y, x + 1]!=null){
                        Console.Write("Right, ");
                        possibleDirections[1]=true;
                    }
                }
                catch(Exception){
                    possibleDirections[1]=false;
                }
                try
                {
                    if(map[y+1, x]!=null){
                        Console.Write("Down, ");
                        possibleDirections[2]=true;
                    }
                }
                catch(Exception){
                    possibleDirections[2]=false;
                }
                try
                {
                    if(map[y, x -1]!=null){
                        Console.Write("Left, ");
                        possibleDirections[3]=true;
                    }
                }
                catch(Exception){
                     possibleDirections[3]=false;
                }
                Console.Write(" exists.\n");
                
                if(possibleDirections[0]==true){
                    Console.Write("The tile above it:"+map[y, x].getElevation()+" - " + map[y-1,x].getElevation());
                    calculateDistance(map[y,x].getElevation(), map[y-1,x].getElevation());
                }
                if(possibleDirections[1]==true){
                     Console.Write("The tile right of it:"+map[y, x].getElevation()+" - " + map[y,x+1].getElevation());
                     calculateDistance(map[y,x].getElevation(), map[y, x+1].getElevation());
                }
                if(possibleDirections[2]==true){
                     Console.Write("The tile bellow it:"+map[y, x].getElevation()+" - " + map[y+1,x].getElevation());
                     calculateDistance(map[y,x].getElevation(), map[y+1,x].getElevation());
                }
                if(possibleDirections[3]==true){
                     Console.Write("The tile left of it:"+map[y, x].getElevation()+" - " + map[y,x-1].getElevation());
                     calculateDistance(map[y,x].getElevation(), map[y,x-1].getElevation());
                }
            }
        }

        public static bool[,] checkForEnemies(int side, int x, int y, Tile[,] map){
            bool[,] possibleEnemies = {{false,false,false,},{false,false,false,},{false,false,false}};
            // 1. up, 2. up_Right, 3. right, 4. down_Right, 5. down, 
            //6. down_Left, 7. left, 8. up_Left
            bool oneEnemyFound = false;
            int player_side = side;
            if(side==null) // if side wasnt declared. 
                player_side = map[y,x].getPiece().getSide();
            //checking surroundings
            for (int i = 0; i < 3;i++){
                for(int j = 0; j < 3; j++){
                    try{ //from -1 to 1
                        if(map[y+i-1,x+j-1].getPiece().getSide() != player_side){
                            possibleEnemies[i,j] = true;
                            oneEnemyFound = true;
                        }
                            
                    }
                    catch(Exception e){

                    }
                }
            }
            if(oneEnemyFound)
                displayPossibleEnemies(possibleEnemies, x, y, map);
            return possibleEnemies;
        }
        public static void displayPossibleEnemies(bool[,] possibleEnemies, int x, int y, Tile[,] map){
            Console.WriteLine("There was an enemy found to the: ");
            for(int i = 0; i < possibleEnemies.GetLength(0); i++){
                for(int j = 0; j < possibleEnemies.GetLength(1); j++){
                    if(possibleEnemies[i,j] == true){
                        
                        if (i == 0  && j == 2)
                            Console.Write("top-right, ");
                        if (i == 1  && j == 2)
                            Console.Write("right, ");
                        if (i == 2  && j == 2)
                            Console.Write("bottom-right, ");
                        if (i == 0  && j == 1)
                            Console.Write("top, ");
                        if (i == 1  && j == 1)
                            Console.Write("center, "); //not possible, unless checking somewhere else
                        if (i == 2  && j == 1)
                            Console.Write("bottom, ");
                        if (i == 0  && j == 0)
                            Console.Write("top-left, ");
                        if (i == 1  && j == 0)
                            Console.Write("left, "); 
                        if (i == 2  && j == 0)
                            Console.Write("bottom-left, ");
                        
                    }
                }
            }
            Console.WriteLine("Do you wisht to attack a unit? Y/N");
            string input = Console.ReadLine();
            if(input=="y" || input == "Y")
                map[y,x].getPiece().getAttacks(x,y,map);
        }
        
    }
    class Tile
    {
        piece Piece;
        int Elevation;
        bool Tunnel = false;
        bool Mine = false;
        
        public Tile(int elevation)
        {
            Elevation = elevation;
        }

        public int getElevation()
        {
            return this.Elevation;
        }
        public void setPiece(piece gamePiece)
        {
            this.Piece = gamePiece;
        }
        public piece getPiece()
        {
            return this.Piece;
        }
        public void setElevation(int ele)
        {
            this.Elevation = ele;
        }
        public void setTunnel(bool set)
        { 
            this.Mine = set;   
        }
        public bool hasTunnel()
        {
            return this.Tunnel;
        }

        public void setMine(bool set)
        {
            this.Mine = set;
        }
        public bool hasMine()
        {
            return this.Mine;
        }
    }
    class player{
        public player(int orderNumber){
            Console.WriteLine("A Player "+orderNumber+ " has been created. ");
            setOrder(orderNumber);
        }
    
        public static int turn = 1; //says what turn it is
        public static int total_turns = 0; //says how many turns have passed
        public static int moves_per_turn = 10; //says how many moves a player can make per turn
        public static int availableMoves = 10; //says how many moves are left for this turn
        public int order; //who goes first 
        public int gold = 4; // referred to as cp
        public int maxGold = 4; // temporary for testing
        
        public int getTurn(){
            return turn;
        }
        
        public void displayTurn(){
            Console.WriteLine("It is currently Player: "+getTurn()+"'s turn!");
        }
        
        public void nextTurn(){
            Console.WriteLine("This will conclude the player "+turn+"'s turn...");
            if(turn == 1)
                turn = 2;
            else if(turn == 2)
                turn = 1;
            total_turns++;
            gold = maxGold;
            availableMoves = moves_per_turn;
        }
        public void setOrder(int orderNumber){
            order = orderNumber;
        }
        
        public void displayGold(){
            Console.WriteLine("The player: "+turn+" now has "+ getGold() + " gold.");
        }
        public int getGold(){
            return gold;
        }
        
        public void setGold(int gp){ //wanna name the gold cp or gp - but this is just a prototype for moves actually
            gold = gp;
            if(gold <= 0){
                nextTurn();
            }
        }
    
    }
    
    class mainGame
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Tile[,] map = new Tile[9, 9];

            Map.populateMap(rand, map);
            Map.displayMap(map);
            Console.WriteLine();
            
            
            Map.dropMines(rand, map);
            
            
            Map.displayMines(map);
            Console.WriteLine();
            Map.dispMinesAsBool(map);
            Console.WriteLine();

            Map.placePawns(map);
            Map.dispPieceMap(map);
            
            Console.WriteLine("The Map: ");
            Map.displayMap(map);
            
            player player1 = new player(1);
            player player2 = new player(2);

            
            
            int currentTurn = 0;
            
            while (true){
            
                player1.displayTurn();
                Console.Write("Do you want to observe a tile or buy a unit? \n\n1. Observe \n2. Buy \n3. View Map \n");
                
                int inp = Convert.ToInt32(Console.ReadLine());
                
                if(inp == 3){
                    Map.displayBoth(map);
                    continue; //restarts while loop
                }

                Console.WriteLine("Enter in the x and y coordinates of a square on the board: ");
                int X = Convert.ToInt32(Console.ReadLine());
                Console.Write(", ");
                int Y = Convert.ToInt32(Console.ReadLine());
                if(inp == 1){
                    Map.ObserveTile(X,Y, map);
                    int cost = Map.ObserveUnit(X,Y,map, player1);
                    player1.setGold(player1.gold-cost); 
                    if(cost!=0) player1.displayGold();
                }
                if(inp == 2){
                    int cost = Map.getCost(Map.listOptions(map, X, Y));
                    player1.setGold(player1.gold-cost); 
                    if(cost!=0) player1.displayGold();
                }
                
                
            }
        }
    }
}
