---
title: OMYGod - Arch As A Code
subtitle: проектируем архитектуру через код
lang: ru
output:
  pdf_document:
    path: /OMYGod.pdf
markdown:
  image_dir: /assets
  path: ../OMYGod.md
  ignore_from_front_matter: true
  absolute_image_path: true
export_on_save:
  markdown: true
  pandoc: true
---

# Собираются архитекторы и архитектурируют архитектуру посредством кода

> Пока не публично - те кто смотрит за коммитами увидят раньше всех

текущий основной вариант запуска: **Клонирование**

```bash
git clone https://github.com/aliczin/omygod 
```

после чего: **Прямая локальная сборка**

@import "../publisher.bat"

### Предисловие

Когда ты вдруг услушишь что-то про архитекторов, тебе возможно захочется им стать. А что такое вообще архитектор ? Говорят это какие-то космические люди - очень шибко умные которые почему-то всегда заняты рисованием бумажек, кубиков и стрелочек.

Примерно таких:

@import "../uml/HttpHealthChecks.Arch.plantuml"

А откуда берется знание о кубиках ? Как понять куда нарисовать стрелочку ? Особенно если ты бывший программист / системный администратор / инженер по безопасности.

Ситуацию усугубляет еще и тот факт - что архитекторами называют всех: архитектора программного обеспечения, архитектора инфраструктуры, архитектора СУБД, архитектора по безопасности... Единственные кто выбивается из этой чудесной коллекции архитекторов - это инженер-проектировщик систем автоматизированного управления (САПР) и автоматизированных систем управления технологическими процессами (АСУТП)... На всякий случай напомним что в волшебном мире ИТ о котором мы в целом будем говорить, присутствует еще и менеджмент, а также экономика. Не говоря уже о разработчиках, аналитиках, инженеров по качеству, системных админситраторах... И пользователей тех продуктов системная архитектура которых проектируется.

Усилим накал !!! Для работы архитекторов еще и существуют несколько противоречивых стандартов:

* [06.003 Архитектор программного обеспечения - проффесиональный стандарт должности](https://profstandart.rosmintrud.ru/obshchiy-informatsionnyy-blok/natsionalnyy-reestr-professionalnykh-standartov/reestr-professionalnykh-standartov/index.php?ELEMENT_ID=57023) [^1]

в котором указано что: 

> Основная цель вида профессиональной деятельности: Создание и сопровождение архитектуры программных средств, заключающейся в синтезе и документировании решений о структуре; компонентном устройстве; основных показателях назначения; порядке и способах реализации программных средств в рамках системной архитектуры; реализации требований к программным средствам; контроле реализации и ревизии решений

Что в этом стандарте интересного ? Ключевое это слово "решения"

Добавим немного психологии ? Дело в том что каждая личность при развитии проходит определенный жизненный путь развития [^2]:

* "первый" - жизнь-плохая
* "второй" - МОЯ жизнь плохая
* "третий" - Я крутой , а ты нет
* "четвертый" - МЫ крутые архитекторы
* "пятый" - "жизнь прекрасна"

Почти всегда архитекторами становятся личности уровня 3 или выше. Правильные архитекторы находятся обычно на уровне "четыре" - поэтому в крупных организациях всегда присутствует архитектурный комитет, где обычно применяют методики креативности:

* фасилитационная сессия вида `Мозговой штурм`
* фасилитационная сессия вида `Открытое кафе`
* личная методика проектирования `Теория решения изобретательских задач`
* личная методика критического взгляда `Латеральное мышление`
* распределенная методика экспертных оценок `Метод Дельфи`

И вот для чего такие сложности ? Кому вообще нужен такой подход ? Ведь намного проще поставить Birtix24, купить 1С конфигурацию, прикупить 1 принтер, один Microtic-hex, Zyxel WiFi и один компьютер - и вот у тебя уже Enterprise - безо всяких архитекторов.

Хуже того - вот в стандарте на должность написано [E/04.5 Оценка и выбор архитектуры развертывания каждого компонента](https://profstandart.rosmintrud.ru/obshchiy-informatsionnyy-blok/natsionalnyy-reestr-professionalnykh-standartov/reestr-trudovyh-funkcij/index.php?ELEMENT_ID=56914&CODE=56914) [^1] - это трудовая функция. Но тот кто читал про DevOps и LXC уже примерно понимает или догадывается куда я веду.

@import "../examples/diagrams/HelloSystem-C4.plantuml"

Работа архитектора - это фактически работа в формате корпоративной культуры над комплексными системами. Причем облик этих систем и будет определен в процессе работы архитектора. Однако:

Увлечение крупных корпораций технологией внутренних стартапов - когда команда имеющая идею, начинает проверять свою гипотезу, без проработки архитектуры. И пока ты будешь рисовать свои кубики - они уже выйдут на первый раунд инвестиций ;-).

Поэтому приходится заниматься не только декомпозицией систем, но и обратным синтезом с рефакторингом. Потому что стартаперы могут выбрать MySQL в виде БД для системы которой будут пользоваться все пользователи в мире. Или даже PHP в качестве серверной технологии.

## Часть 1 - Декомпозиция

Поверь на слово - в основном твоя работа на 90% процентов будет состоять из синтеза и надзора, и только на 10% из фазы декомпозии. Но - чтобы что-то синтезировать, как ты наверное помнишь из школьной программы по химии, придется вначале декомпозировать вещество до состояния формул. Чтобы потом повторят процесс.

Прочувствуй еще раз:

> Декомпозиция идеальной системы на компоненты - это навык. А синтез решения - это изобретение.

Поэтому мы начнеем с декомопозии. Но предварительно что понимать всё до конца - тебе придется сделать так, чтобы примеры кода в даном повествовании ты мог/могла воспроизвести в своём редакторе:

* Установи oscript.io на свой локальный компьютер удобным для тебя способом
* выполни `opm install omygod` чтобы у тебя установился пакет для работы архитектора и можешь приступать

```{hide=true cmd="oscript" args=["-encoding=utf-8","$input_file"] .line-numbers output="markdown"} 
#Использовать omygod

ПространствоАрхитектора = Новый РабочееПространствоАрхитектора("Привет архитектор", "А что тут");

Модель = ПространствоАрхитектора.Модель;
НаборПредставлений = ПространствоАрхитектора.Представления;

Модель.ДобавитьПлатформуПредприятия("Рабочий компьютер архитектора");

СайтOscript = Модель.ДобавитьПрограммнуюСистему("OScript.io", 
	"главный сайт OneScript");

GithubOVM = Модель.ДобавитьПрограммнуюСистему("OVM", 
	"пакет управления версиями OScript");

ПользовательСайта = Модель.ДобавитьПерсону("Специалист", "человек который лежает начать архитектурировать архитектуру");

ПользовательСайта.Использует(СайтOscript,"скачивает инсталятор");

ПользовательСайта.Использует(GithubOVM, "скачивает систему управления версиями ovm.exe");


СистемноеПредставление = НаборПредставлений.СоздатьСистемноеПредставление(
	СайтOscript,
	"АрхитектураСистемы",
	"Как скачать OneScript на свой машину"
);

СистемноеПредставление.ДобавитьВсеПрограммныеСистемы();
СистемноеПредставление.ДобавитьВсехЛюдей();


Сообщить(
    "```puml
    |" + ПространствоАрхитектора.ПолучитьПредставлениеUMLC4() + "
    |```"
);

```

### Рабочее пространство архитектора

Всё конечно же начинается с контекста.  

```bsl {cmd="oscript" args=["-encoding=utf-8","$input_file"] .line-numbers} 
#Использовать omygod

ПространствоАрхитектора = Новый РабочееПространствоАрхитектора("Привет архитектор", "А что тут");

Сообщить("Рабочее пространство архитектора это объект - типа: " + ТипЗнч(ПространствоАрхитектора)
);

```

> Функция `ТипЗнч(ЧтоТо)` - это типовая функция языка BSL для определения абстрактного типа значения. Вообще конечно просится более качественная обертка, например `Значение.Тип()`

В самом деле: всё действительно начинается с контекста - который определяет:

* **Наименование пространства** - наименование того контекста который вы собираетесь проектировать
* **Описание пространства** - более подробное описание контекста

```bsl {cmd="oscript" args=["-encoding=utf-8","$input_file"] .line-numbers} 
#Использовать omygod

ПространствоАрхитектора = Новый РабочееПространствоАрхитектора(
  "Архитектура Lustin.Org", 
  "комплект программно аппаратного обеспечения для
  |автоматизации социальной и повседневной
  |деятельности в целях сокращения затрат на
  |координацию "
);

Сообщить(
  СтрШаблон(
    "Создано пространство для проектирования архитектуры
    |%1
    |========
    |%2",
  ПространствоАрхитектора.Наименование,
  ПространствоАрхитектора.Описание)
);
```

Вопрос что указывать в наименование и описании достаточно философский - фактически после прочтения данного материала у тебя сформируется собственная позиция как и что указывать в рамках контекста своей работы.

Как только ты создал своё пространство - у тебя уже есть объектное представление в текстовом виде - с которым ты впоследствии сможешь работать из сторонних систем. Например отправляя события изменений плановой архитектуры.

```bsl {cmd="oscript" args=["-encoding=utf-8","$input_file"] .line-numbers} 
#Использовать omygod

ПространствоАрхитектора = Новый РабочееПространствоАрхитектора(
  "Архитектура Lustin.Org", 
  "комплект программно аппаратного обеспечения для
  |автоматизации социальной и повседневной
  |деятельности в целях сокращения затрат на
  |координацию "
);

Сообщить(ПространствоАрхитектора.ПолучитьПредставлениеJSON());

```

Изучая данных **JSON** [^JSON] у тебя уже должно сложится впечатление сколько всего нужно учесть для проектирования. Но мы начнем с модели и с общего системного представления

### Участники банкета "Модели архитектуры" и "Представления архитектуры"

Чтобы добится первого результата нам нужно добавить в наше пространство одну модель и одно представление. И представить это в виде **UML** [^UML] диаграммы

```bsl {cmd="oscript" args=["-encoding=utf-8","$input_file"] .line-numbers output="markdown"} 
#Использовать omygod

МоеПространство = Новый РабочееПространствоАрхитектора("Тесть", "");

Вася = МоеПространство.Модели.ДобавитьПерсону("Вася","Хороший человек");
Система = МоеПространство.Модели.ДобавитьПрограммнуюСистему("Супер-Система", "специально для Васи");

Вася.ИспользуетСистему(Система, "Очень хитрым способом");

Ландшафт = МоеПространство.Представления.СоздатьСистемныйЛандшафт(
  "ГлавноеПредставление","простенький примерчик системного ладшафта"
);

Ландшафт.ДобавитьВсё();

Сообщить(
  "> Можно вставлять в Markdown:
  |```puml
  |" + МоеПространство.ПолучитьПредставлениеUMLC4() + "
  |```"
);
```

> **puml** - это сокращение от *PlantUML* [^PUML] - инструмента для преобразования *UML* [^UML] в различные форматы

А теперь попробуем разобратсья, что же здесь происходит:

* мы создали Рабочее пространство
* определили Персону-роль-человека
* определили Систему
* связали систему и персону явно указав использование
* сформировали представление в формате C4 [^C4UML]

Другой вариант исполнения

```bsl {cmd="oscript" args=["-encoding=utf-8","$input_file"] .line-numbers output="markdown"} 
#Использовать omygod

МоеПространство = Новый РабочееПространствоАрхитектора("Тесть", "");

Вася = МоеПространство.Модели.ДобавитьПерсону("Вася","Хороший человек");
Система = МоеПространство.Модели.ДобавитьПрограммнуюСистему("Супер-Система", "специально для Васи");

Вася.ИспользуетСистему(Система, "Использует очень хитрым способом");

СистемныйВзгляд = МоеПространство.Представления.СоздатьСистемноеПредставление(Система,
  "Представление-От-Системы","системное представление - виденье от системы"
);

СистемныйВзгляд.ДобавитьВсехЛюдей();
СистемныйВзгляд.ДобавитьВсеПрограммныеСистемы();

Сообщить(
  "
  |```puml
  |" + МоеПространство.ПолучитьПредставлениеUMLC4() + "
  |```"
);
```


## Глоссарий, cсылки и библиография

[^JSON]: Java Script Object Notation

[^UML]: Universal Modeling Language

[^PUML]: PlantUML - java инструмент для работы с форматом UML

[^C4UML]: C4UML - расширение UML для отображения четырех уровней системного виденья

[^1]: Стандарт должности системный архитектор
https://profstandart.rosmintrud.ru/obshchiy-informatsionnyy-blok/natsionalnyy-reestr-professionalnykh-standartov/reestr-professionalnykh-standartov/index.php?ELEMENT_ID=57023

[^2]: HR книга по корпоративной культуре
https://www.mann-ivanov-ferber.ru/books/lider-i-plemya/
