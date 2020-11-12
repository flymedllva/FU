<script>
    import {writable} from "svelte/store";
    import {fade, fly} from 'svelte/transition';
    import {flip} from 'svelte/animate';
    import {store} from "./store";

    let newUserForm = false
    let editUserForm = false

    let idEditForm = null
    let nameEditForm = ""
    let semScoreEditForm = ""
    let examScoreEditForm = ""
    let disciplineEditForm = ""

    let nameUserForm = ""
    let semScoreUserForm = ""
    let examScoreUserForm = ""
    let disciplineUserForm = ""


    function switchEditForm(id, name, semScore, examScore, discipline) {
        if (editUserForm) {
            idEditForm = null
            nameEditForm = ""
            semScoreEditForm = ""
            examScoreEditForm = ""
            disciplineEditForm = ""
            editUserForm = false
        } else {
            idEditForm = id
            nameEditForm = name
            semScoreEditForm = semScore
            examScoreEditForm = examScore
            disciplineEditForm = discipline
            editUserForm = id
        }
    }

    function switchNewUserForm() {
        if (newUserForm) {
            nameUserForm = ""
            semScoreUserForm = ""
            examScoreUserForm = ""
            disciplineUserForm = ""
        }
        newUserForm = !newUserForm
    }

    function checkUser(name, semScore, examScore, discipline) {
        if (name && semScore && examScore && discipline) {
            if (examScore > 60 || examScore < 0)
                alert("Неправильные баллы за экзамен")
            else if (semScore > 40 || semScore < 0)
                alert("Неправильные баллы за семестр")
            else {
                return {"name": name, "exam_score": examScore, "sem_score": semScore, "discipline": discipline}
            }
        } else {
            alert("Введите все данные")
        }
        return false
    }

    function editUser(idx, id, name, semScore, examScore, discipline) {
        let user = checkUser(name, semScore, examScore, discipline)
        if (user) {
            user.id = id
            store.edit(idx, user)
            switchEditForm()
        }
    }

    function addUser() {
        let newUser = checkUser(nameUserForm, semScoreUserForm, examScoreUserForm, disciplineUserForm)
        if (newUser) {
            switchNewUserForm()
            store.add(newUser)
        }
    }
</script>

<div class="container">
    <div class="item">
        <div class="task-title">
            <h1>Task 4</h1>
            <h4>ПИ18-1</h4>
            <h4>Гриднев Дмитрий Владимирович</h4>
            <ul>
                <li>Отображаться в виде нумерованного списока</li>
                <li>Содержать несколько 5 полей, первое поле ключевое. (Содержание придумать)</li>
                <li>Добавление элемента справочника по кнопке</li>
                <li>Позволять удалять отдельные элементы по кнопке у каждого элемента</li>
            </ul>
        </div>
    </div>
    <div class="item">
        {#if $store.length > 0}
            <hr>
        {/if}
        {#each $store as item, i (item.id)}
            <div animate:flip in:fade out:fly={{x:100}}>
                <p>
                    {#if editUserForm === item.id}
                        <label>
                            {item.id} -
                            <input bind:value={disciplineEditForm} placeholder="Дисциплина">
                            <input bind:value={nameEditForm} placeholder="Имя">:
                            <input bind:value={semScoreEditForm} type=number placeholder="Баллы семестра" min=0 max=40>
                            +
                            <input bind:value={examScoreEditForm} type=number placeholder="Баллы экзамена" min=0 max=60>
                        </label>
                        <button on:click={() => editUser(i, item.id, nameEditForm, semScoreEditForm, examScoreEditForm, disciplineEditForm)}>
                            Сохранить
                        </button>
                        <button on:click={switchEditForm}>Отмена</button>
                    {:else}
                        {item.id} - <b> {item.discipline}, {item.name}</b>: {item.sem_score} + {item.exam_score}
                        = {item.exam_score + item.sem_score}
                        {#if editUserForm === false}
                            <button on:click={() => switchEditForm(item.id, item.name, item.sem_score, item.exam_score, item.discipline)}>
                                Редактировать
                            </button>
                            <button on:click={() => store.delete(i)}>Удалить</button>
                        {/if}
                    {/if}
                </p>
            </div>
        {/each}
        {#if $store.length > 0}
            <hr>
        {/if}
        {#if newUserForm}
            <label>
                <input bind:value={disciplineUserForm} placeholder="Дисциплина">
                <input bind:value={nameUserForm} placeholder="Имя">
                <input bind:value={semScoreUserForm} type=number placeholder="Баллы семестра" min=0 max=40>
                <input bind:value={examScoreUserForm} type=number placeholder="Баллы экзамена" min=0 max=60>
            </label>
            <button on:click={addUser}>Добавить</button>
            <button on:click={switchNewUserForm}>Отмена</button>
        {:else}
            <button on:click={switchNewUserForm}>Добавить</button>
            {#if $store.length > 0}
                <button on:click={store.clear}>Удалить все</button>
            {/if}
        {/if}

    </div>
</div>


<style>
    :global(body) {
        margin: 0;
        padding: 40px;
    }

    p {
        height: 22px;
    }

    .item {
        margin: 5px;
        width: calc(100% - 10%);
    }

    .task-title h1 {
        margin-top: 0;
        margin-bottom: 8px;
    }

    .task-title h4 {
        margin-top: 0;
        margin-bottom: 4px;
    }

</style>
