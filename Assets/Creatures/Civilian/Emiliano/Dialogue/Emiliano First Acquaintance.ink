->main
=== main ===
Чем могу помочь. #speaker: I
    + [Подскажи, где можно приобрести оружие для убийство монстров?] #speaker: I
        Можно приобрести в магазине. Но обычные пистолеты ранят монстров лишь самого низшего уровня, не имеющих магию защиты. #speaker: Esther
        Лучше постарайся найти что-то более мощное.#speaker: Esther
        * * [А где я могу приобрести более сильное оружие?]
            В магазине магических оружий возле паба. 
            * * * [У меня есть еще вопросы] #speaker: I
                Валяй. #speaker: Esther
                -> main
        * * [Могу ли я ранить людей им?] #speaker: I
             Можешь, но советую этого не делать.
            * * * [У меня есть еще вопросы] #speaker: I
                Валяй. #speaker: Esther
                -> main
            * * * [Спасибо за информацию] #speaker: I
                Обращайся. #speaker: Esther
                -> DONE
        * * [У меня есть еще вопросы] #speaker: I
            Валяй. #speaker: Esther
            -> main
    + [Не подскажешь, где я могу приобрести жилье?] #speaker: I
        У нас есть несколько хостелов и отелей. Как неплохие, так и не очень. Вообщем, смотря что любишь. #speaker: Esther
        * * [Есть ли быстрые способы заработать на отель?] #speaker: I
                Ты можешь выполнить мое небольшое поручение, и я дам тебе денег на одну ночь в отеле.
                * * * [Хорошо, я выполню твое желание] #speaker: I
                    Отлично! Я рад, что ты согласился помочь мне!
                    * * * * [У меня есть еще вопросы] #speaker: I
                     Валяй. #speaker: Esther
                    -> main
                -> DONE
                * * * [Вынужден отказать] #speaker: I
                    Ладно уж, как скажешь. #speaker: Esther
                    * * * * [У меня есть еще вопросы] #speaker: I
                     Валяй. #speaker: Esther
                    -> main
                
    + [Подскажи, можно ли получать прибыль за убийство монстров?] #speaker: I
            Конечно. Например, устроится в компанию, которая вербует магов. Но вполне можно убивать монстров и в одиночку, но для этого тебе нужно разрешение на выход за магический барьер. #speaker: Esther
            * * [От чего нужно разрешение?] #speaker: I
                Это сделано с целью защиты для самоуверенных новичков. #speaker:Esther
                    * * * [У меня есть еще вопросы] #speaker: I
                    Валяй. #speaker: Esther
                    -> main 
            * * [А приручить монстров?] #speaker: I
                Хах, скажу только, что таких случаев в нашей деревни не встречалось, ибо что это очень сложно. #speaker: Esther
                * * * [У меня есть еще вопросы] #speaker: I
                Валяй. #speaker: Esther
                -> main        
            * * [У меня есть еще вопросы] #speaker: I
            Валяй. #speaker: Esther
            -> main    
            
            
=== DONE ===
-> DONE