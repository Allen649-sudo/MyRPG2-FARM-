->main
=== main ===
Что интересует? #speaker: I
    + [Как дела в деревне?] #speaker: I
        В целом всё спокойно. Но Монстры из леса в последнее время стали часто вылезать по ночам, поэтому держим ухо востро. 
        * * [Что ты можешь рассказать о лесе?]
            Лес полон монстров с темной магией. Исследование его — опасное дело. У нас есть защитный барьер вокруг деревни, но не стоит расслабляться. #speaker: Esther
            * * * [У меня есть еще вопросы] #speaker: I
                Слушаю. #speaker: Esther
                -> main
            * * * [Спасибо за информацию] #speaker: I
                Не за что! Обращайся если потребуется. #speaker: Esther
                -> DONE
        * * [Спасибо за информацию] #speaker: I
            Не за что! Обращайся если потребуется. #speaker: Esther
            -> DONE
        * * [У меня есть еще вопросы] #speaker: I
            Слушаю. #speaker: Esther
            -> main
    + [Как можно заработать в деревне?] #speaker: I
        Если у тебя есть магические способности, можешь попробовать пройти отбор в одну из магических компаний. Они отправляют магов на охоту на монстров и исследование леса. #speaker: Esther
        * * [Как стать магом?] #speaker: I
            Если у тебя есть магические способности, можешь попробовать пройти отбор в одну из магических компаний. Они отправляют магов на охоту на монстров и исследование леса. #speaker: Esther
            * * * [Спасибо за информацию] #speaker: I
                Не за что! Обращайся если потребуется. #speaker: Esther
                -> DONE
            * * * [У меня есть еще вопросы] #speaker: I
                Слушаю. #speaker: Esther
                -> main
        * * [Какие еще есть способы?] #speaker: I
            Ты можешь заработать на продаже рыбы, овощей и тому подобное. Еще в местном пабе есть свободная вакансия офифианта.
            * * * [Есть ли быстрые способы заработка?] #speaker: I
                Ты можешь выполнить мое небольшое поручение, и я дам тебе денег на одну ночь в отеле.
                * * * * [Хорошо, я выполню твое желание] #speaker: I
                    Отлично! Я рад, что ты согласился помочь мне!
                -> DONE
                * * * * [Спасибо за информацию] #speaker: I
                    Не за что! Обращайся если потребуется. #speaker: Esther
                -> DONE
                * * * * [У меня есть еще вопросы] #speaker: I
                Слушаю. #speaker: Esther
                -> main
            * * * [Спасибо за информацию] #speaker: I
                Не за что! Обращайся если потребуется. #speaker: Esther
                -> DONE
            * * * [У меня есть еще вопросы] #speaker: I
                Слушаю. #speaker: Esther
                -> main
        * * [Спасибо за информацию] #speaker: I
            Не за что! Обращайся если потребуется. #speaker: Esther
            -> DONE    
        * * [У меня есть еще вопросы] #speaker: I
            Слушаю. #speaker: Esther
            -> main
    + [Сколько жителей в деревне?] #speaker: I
        Здесь проживает около 85,000 человек. Мы все работаем вместе, чтобы поддерживать безопасность и порядок. #speaker: Esther
        * * [Спасибо за информацию] #speaker: I
            Всегда пожалуйста. #speaker: Esther
            -> DONE
        * * [У меня есть еще вопросы] #speaker: I
            Слушаю. #speaker: Esther
            -> main
            
=== DONE ===
-> DONE