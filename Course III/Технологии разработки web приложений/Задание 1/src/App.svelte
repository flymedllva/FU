<script>
    import { writable } from "svelte/store";

    const one = writable(Number.parseInt(localStorage.getItem("one")) || randomInteger(1, 99999));
    const two = writable(Number.parseInt(localStorage.getItem("two")) || randomInteger(1, 99999));

    one.subscribe(val => localStorage.setItem("one", val));
    two.subscribe(val => localStorage.setItem("two", val));

    function randomInteger(min, max) {
        let rand = min + Math.random() * (max + 1 - min);
        return Math.floor(rand);
    }

    async function changeNumbers() {
        if ((Number.isInteger($one)) && (Number.isInteger($two))) {
            $one = $one + $two;
            $two = $one - $two;
            $one = $one - $two;
        } else {
            alert("Введены не числа")
        }
    }
</script>

<div class="container">
    <div class="item">
        <div class="task-title">
            <h1>Task 1</h1>
            <h4>ПИ18-1, Вариант 3</h4>
            <h4>Гриднев Дмитрий Владимирович</h4>
            <p>В окне 3 элемента: 2 элемента для ввода текста и кнопка. Вводится 2 числа. По нажатию кнопки числа
                меняются
                местами</p>
        </div>
    </div>
    <div class="item">
        <label>
            <input type=number bind:value={$one}>
            <input type=number bind:value={$two}>
        </label>
        <br>
        <button on:click={changeNumbers}>
            Поменять местами
        </button>
    </div>
</div>


<style>
    :global(body) {
        margin: 0;
    }

    .container {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        background-color: #eee;
        height: 100vh;
    }

    .item {
        width: 300px;
        margin: 5px;
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
