# Визуелно Програмирање Проект

## 1. Опис на апликацијата
Апликацијата е имплементација на Single player игра каде играчот е мачка и се движи низ околината за да ја достигне целта. 

## 2. Начин на играње
### 2.1. Почетно мени
Најпрвин се појавува Почетно мени прозорец каде има играчот опции да започне нова игра, да ја изгаси апликацијата, да види опис за играта и да ги избрише сите претходно зачувани поени.<br />
<p align="center">
  <img src="/Screenshots/start_menu.png" alt="start menu for the game with buttons for start, quit, information, deletion of scores">
</p>

### 2.2. Нова игра
Со клик на копчето “START” од Почетното мени се започнува играта и почнува позадинска музика. Во околината има дрва, риби, куќи и езера. Околината секогаш е различна, односно се генерираат дрва, езера, куќи и риби на различни места, освен финалната куќа и куќите за насока кои се генерираат во одредени делови. 
Во десниот горен агол се прикажани моменталните поени, најдобрите поени до сега, “Health bar” кој се намалува кога ќе започне играта, копчиња за пауза и продолжување на играта.
Играчот е анимиран и се движи во 4 насоки, десно, лево, горе, долу со копчињата со стрелки на тастатурата.<br />
<p align="center">
  <img src="/Screenshots/game.png" alt="screenshot of the gameplay">
</p>

Со собирање на риби играчот добива 5 поени, но исто така се зголемува и вредноста на “Health bar”-от. 
Има три различни видови на куќи. Едните даваат храна, други даваат насоки за каде да се движи играчот и третите имаат кучиња. При пристигнување до некоја од куќите се појавува порака. Пораките се појавуваат само кога играчот ќе застане сам и ќе се отпушти копчето за движење. Куќите кои даваат храна носат 5 поени, додека куќите кои имаат куче одземаат 5 поени. Куќите кои кажуваат насока не носат поени.<br />
<p align="center">
  <img src="/Screenshots/food_message.png" alt="food message">
</p>
<p align="center">
  <img src="/Screenshots/direction_message.png" alt="direction message">
</p>
<p align="center">
  <img src="/Screenshots/dog_message.png" alt="dog message">
</p>

Ако играчот дојде до езеро, се појавува порака и се одземаат 5 поени.<br />
<p align="center">
  <img src="/Screenshots/lake_message.png" alt="lake message">
</p>

### 2.3. Информации прозорец
Краток опис за играта, прозорецот е scrollable.<br />
<p align="center">
  <img src="/Screenshots/information.png" alt="scrollable window with information about the game">
</p>

### 2.4. Бришење сочувани поени
<p align="center">
  <img src="/Screenshots/scores_message.png" alt="message about permission to delete previous scores">
</p>

### 2.5. Крај на играта
Играта може да се заврши на два начини. Кога играчот ќе ја достигне целта (финалната куќа – домот) или кога ќе се испразни “Health bar”-от. Се појавува “Game Over” прозорец кој има опции да се изгаси играта или да се почне од почеток, односно се отвара Почетното мени. Исто така завршува музиката.<br />
<p align="center">
  <img src="/Screenshots/game_over.png" alt="game over window with retry and quit buttons">
</p>

## 3. Решение на апликацијата
За секој тип на објект во околината се користи List<PictureBox> кој се полни со соодветните елементи. 
```csharp
PictureBox pbHome;
List<PictureBox> pbFish = new List<PictureBox>();
List<PictureBox> pbHouses = new List<PictureBox>();
List<PictureBox> pbLakes = new List<PictureBox>();
List<PictureBox> pbTrees = new List<PictureBox>();
List<PictureBox> pbHousesDogs = new List<PictureBox>();
List<PictureBox> pbHousesRight = new List<PictureBox>();
List<PictureBox> pbHousesDiagonal = new List<PictureBox>();
PictureBox pbHouseMiddle;
PictureBox pbHouseDown;
```
Пример за додавање на објект во листа:
```csharp
private void addFish(int x, int y)
        {
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile(@"Resources\fish.png");
            pb.Location = new Point(x, y);
            pb.Width = 56;
            pb.Height = 36;

            if (pbFish.Count == 0)
            {
                pbFish.Add(pb);
                this.Controls.Add(pb);
            }
            if (overlap(pb) && pbFish.Count>0)
            {
                pbFish.Add(pb);
                this.Controls.Add(pb);
            }
        }
```
Играчот е посебен PictureBox ставен на самата форма. За анимација на играчот се користи готова функција од [Moo ICT](https://www.mooict.com/c-sharp-tutorial-create-4-way-sprite-movement-animation-using-net-windows-form-and-visual-studio/).
Играчот не се движи, напротив околината се движи. Логиката за движење е искористена од [Stack Overflow](https://stackoverflow.com/questions/22861825/controling-the-moving-picturebox).
Се користи и Random класата за генерирање на x и y позициите за секој објект. 
Кога се генерираат објекти на random позиции тие мора да не се преклопуваат, за тоа се користи готовата функција:
```csharp
        private bool IsTouching(PictureBox p1, PictureBox p2)
        {
            if (p1.Location.X + p1.Width <= p2.Location.X)
                return false;
            if (p2.Location.X + p2.Width <= p1.Location.X)
                return false;
            if (p1.Location.Y + p1.Height <= p2.Location.Y)
                return false;
            if (p2.Location.Y + p2.Height <= p1.Location.Y)
                return false;
            return true;
        }
```

## 4. Опис на функција
Кога играчот ќе биде во близина на некој објект кој дава порака, тој може да се движи во сите три насоки освен таа каде што до него е објектот односно во која насока го “удрил”. Функцијата не е целосно функционална, има простор за грешки но сепак работи.
```csharp
private bool IsHitRight(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.X + pb1.Width >= pb2.Location.X - 40 && pb1.Location.X + pb1.Width <= pb2.Location.X + pb2.Width && pb1.Location.Y <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y + pb1.Height >= pb2.Location.Y - 50 && pb1.Location.Y + pb1.Height <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y >= pb2.Location.Y - 50;
        }
        private bool IsHitLeft(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.X <= pb2.Location.X + pb2.Width + 40 && pb1.Location.X >= pb2.Location.X && pb1.Location.Y <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y + pb1.Height >= pb2.Location.Y - 50 && pb1.Location.Y + pb1.Height <= pb2.Location.Y + pb2.Height + 50 && pb1.Location.Y >= pb2.Location.Y - 50;
        }
            private bool IsHitUp(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.Y <= pb2.Location.Y + pb2.Height + 40 && pb1.Location.Y >= pb2.Location.Y && pb1.Location.X >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width <= pb2.Location.X + pb2.Width + 50 && pb1.Location.X <= pb2.Location.X + pb2.Width + 50;
        }
        private bool IsHitDown(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Location.Y + pb1.Height >= pb2.Location.Y - 40 && pb1.Location.Y + pb1.Height <= pb2.Location.Y + pb2.Height && pb1.Location.X >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width >= pb2.Location.X - 50 && pb1.Location.X + pb1.Width <= pb2.Location.X + pb2.Width + 50 && pb1.Location.X <= pb2.Location.X + pb2.Width + 50;
        }
```
Се проверуваат координатите на играчот и објектот и колку се блиску еден до друг во зависност од која насока ќе се удри објектот.
Една од функциите за проверка:
```csharp
private void HitDown()
        {
            foreach (PictureBox pb in pbLakes)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    lake = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHouses)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    house = true;
                    break;
                }
            }
            foreach (PictureBox pb in pbHousesDogs)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    dog = true;
                    break;
                }
            }
            foreach(PictureBox pb in pbHousesRight)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    house_right = true;
                }
            }
            foreach(PictureBox pb in pbHousesDiagonal)
            {
                if (IsHitDown(pbPlayer, pb))
                {
                    down = false;
                    isHit = true;
                    house_diag = true;
                }
            }
            if (IsHitDown(pbPlayer, pbHouseMiddle))
            {
                down = false;
                isHit = true;
                house_middle = true;
            }
            if (IsHitDown(pbPlayer, pbHouseDown))
            {
                down = false;
                isHit = true;
                house_down = true;
            }
        }
```
Потоа овие функции за проверка се користат во timer_Tick() функцијата која проверува во која насока се движи и дали удрил некој објект.
```csharp
private void timer_Tick(object sender, EventArgs e)
        {
            switch (currentDir)
            {
               case Direction.Left:
                    if (pbPlayer.Location.X >= end_left)
                    {
                        HitLeft();
                        if (left)
                        {
                           moveLeft();
                           eatFish();
                        }
                        
                    }
               break;
               case Direction.Right:
                    if (pbPlayer.Location.X + pbPlayer.Width <= end_right)
                    {
                        HitRight();                            
                        if (right)
                        {
                           moveRight();
                           eatFish();
                        }
                    }
                    break;
               case Direction.Up:
                    if (pbPlayer.Location.Y >= end_up)
                    {
                        HitUp();
                        if (up)
                        {
                           moveUp();
                           eatFish();
                        }
                    }
                    break;
               case Direction.Down:
                    if (pbPlayer.Location.Y + pbPlayer.Height <= end_down)
                    {
                        HitDown();
                        if (down)
                        {
                            moveDown();
                            eatFish();
                        }
                    }
                    break;
           }
            
            left = true;
            right = true;
            up = true;
            down = true;
        }
```
Ако играчот удрил некој објект, се проверува каков објект е и се појавува соодветна порака.
```csharp
private void Messages()
        {
            if (isHit && lake)
            {
                MyMessage message = new MyMessage("water_drop.png", "You fell in a lake!");
                message.ShowDialog();
                health -= 5;
                score -= 5;
            }
            if (isHit && house)
            {
                MyMessage message = new MyMessage("cat_food.png", "Here have some food!");
                message.ShowDialog();
                health += 5;
                score += 5;
            }
            if(isHit && dog)
            {
                MyMessage message = new MyMessage("dog.png", "BEWARE OF DOG !!!");
                message.ShowDialog();
                health -= 5;
                score -= 5;
            }
            if(isHit && house_right)
            {
                MyMessage message = new MyMessage("arrow_right.png", "Oh the big house? Hmm.. I think it was somewhere to the right..");
                message.ShowDialog();
            }
            if (isHit && house_diag)
            {
                MyMessage message = new MyMessage("arrow_down.png", "I think it was somewhere down there? Maybe a bit to the right? Im not sure...");
                message.ShowDialog();
            }
            if (isHit && house_middle)
            {
                MyMessage message = new MyMessage("arrow_right.png", "Go right and you'll find your way~");
                message.ShowDialog();
            }
            if (isHit && house_down)
            {
                MyMessage message = new MyMessage("arrow_down.png", "It's right down the hill. Be careful along the way!");
                message.ShowDialog();
            }
        }
```

## Забелешки
Играта има неколку bugs:
-	Некогаш се појавува една слика (дрво, риба, езеро, куќа) која не се движи со околината.
-	Ако се погоди точното место, играчот може да помине низ куќа или езеро, а не треба
-	Некогаш играчот продолжува да се движи без кликање на копчињата кога ќе се појави порака и не е исклучена
-	Пораката би требало да се појави само еднаш, но ако го погоди точното место некогаш се појавува повеќе пати и не може да се исклучи ниту да се движи играчот (треба да се држи копчето Enter и една од стрелките за движење за да се одглави)

## Credits
### Music
- [Midnight Commando - Are You Looking For Me?](https://soundcloud.com/mdntcmd/are-you-looking-for-me)
### Art
- [inkuling](https://inkuling.carrd.co/)
