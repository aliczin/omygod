#Использовать omygod

МоеПространство = Новый РабочееПространствоАрхитектора("Тесть", "Привет");

Вася = МоеПространство.Модели.ДобавитьПерсону("Вася", "Хороший человек");

Ландшафт = МоеПространство.Представления.СоздатьСистемныйЛандшафт(
  "КлючГлавнойСистемы", "простенький примерчик системного ладшафта"
);

Ландшафт.ДобавитьВсё();

Сообщить(МоеПространство.ПолучитьПредставлениеJSON());
