#Использовать omygod

Сообщить("Функция HTTP проверка доступности");

Пространство = Новый РабочееПространствоАрхитектора(
	"Основанное на HTTP протоколе
	|проверка доступности сервисов", "пример того как использовать основанную на HTTP проверку сервисов");

Модель = Пространство.Модель;
НаборПредставлений = Пространство.Представления;

Экосистема = Модель.ДобавитьПлатформуПредприятия("Экосистема OScript");

ПользовательСайта = Модель.ДобавитьПерсону("Пользователь", "Любой пользователь сайта");
СистемаОСкриптВеб = Модель.ДобавитьПрограммнуюСистему("oscript.web", 
	"платформа для развертывания
	|своих Web сервисов на базе ASP.Net");

СвязьПользователяССайтом = ПользовательСайта.ИспользуетСистему(СистемаОСкриптВеб,"WWW");
СвязьПользователяССайтом.УстановитьНаправлениеВправо();

КонтейнерСайт = СистемаОСкриптВеб.ДобавитьКонтейнер("hub.oscript.io", 
	"Реальный веб сервер с поддержкой HTML
	|форм и обеспечивающий чтение списка пакетов",
	"ASP.NET 3.x");

КонтейнерБазаДанных = СистемаОСкриптВеб.ДобавитьКонтейнер("jsondatabase", 
	"База данных JSON", "JSONDB");
КонтейнерБазаДанных.ДобавитьМетку("Database");

КонтейнерСайт.Использует(КонтейнерБазаДанных, "Только чтение", "JSONRead");

УзелРазвертыванияХероку = Модель.ДобавитьУзелРазвертывания("Heroku Application","","micro-instance");

УзелРазвертыванияГитхаб = Модель.ДобавитьУзелРазвертывания(
		"Github Releases","Статическое хранилище собранных пакетов","AmazonS3");

ЭкземплярКонтейнераСайта = УзелРазвертыванияХероку.ДобавитьУзелРазвертывания("ASP.NET Application", 
	"Контур для запуска своих ASP.NET приложений", "Docker").Добавить(КонтейнерСайт);

ЭкземплярКонтейнераБазыДанных = УзелРазвертыванияГитхаб.Добавить(КонтейнерБазаДанных);

ЭкземплярКонтейнераСайта.ДобавитьПроверкуДоступности("Сайт запущен", "https://hub.oscript.io/health");
ЭкземплярКонтейнераБазыДанных.ДобавитьПроверкуДоступности("Релизы можно скачивать", "https://github.com/EvilBeaver/os-hub-frontend/releases");


ПредставлениеРазвертывания = НаборПредставлений.СоздатьПредставлениеРазвертывания(
	СистемаОСкриптВеб,
	"Развертывание", 
	"Диаграмма развертывания с проверкой доступности");

ПредставлениеРазвертывания.Окружение = "Live";
ПредставлениеРазвертывания.ДобавитьВсеУзлыРазвертывания();

НаборПредставлений.ДобавитьСтильЦветаЭлементу("#ffffff");

UML = Пространство.ПолучитьПредставлениеUML();
ЗаписьUML = Новый ЗаписьТекста(
	ОбъединитьПути("uml", "HttpHealthChecks.Arch.plantuml"),	
	"UTF-8");

ЗаписьUML.Записать(UML);
ЗаписьUML.Закрыть();


СистемноеПредставление = НаборПредставлений.СоздатьСистемноеПредставление(
	СистемаОСкриптВеб,
	"АрхитектураСистемы",
	"Системное отображение компонентов"
);

СистемноеПредставление.ДобавитьВсеПрограммныеСистемы();
СистемноеПредставление.ДобавитьВсехЛюдей();


UMLС4 = Пространство.ПолучитьПредставлениеUMLC4();
ЗаписьUML = Новый ЗаписьТекста(
	ОбъединитьПути("uml", "HttpHealthChecks.Arch.C4.plantuml"),	
	"UTF-8");
ЗаписьUML.Записать(UMLС4);
ЗаписьUML.Закрыть();

JSONпредставление = Пространство.ПолучитьПредставлениеJSON();
ЗаписьСтруктуры = Новый ЗаписьТекста(
	ОбъединитьПути("json", "HttpHealthChecks.Arch.C4.json"),	
	"UTF-8"
);
ЗаписьСтруктуры.Записать(JSONпредставление);
ЗаписьСтруктуры.Закрыть();