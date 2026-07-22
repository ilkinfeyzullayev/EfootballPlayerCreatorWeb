// ===== GLOBAL STATE =====

let overall = document.getElementById("overall");

const rootStyles = getComputedStyle(document.documentElement)
const lowStat = rootStyles.getPropertyValue("--low-stat");
const normalStat = rootStyles.getPropertyValue("--normal-stat");
const highStat = rootStyles.getPropertyValue("--high-stat");
const veryHighStat = rootStyles.getPropertyValue("--very-high-stat");

// ===== HELPERS =====

function clamp(value, min, max) {
    return Math.max(min, Math.min(max, value));
}

// ===== RENDERINGS =====

renderStatColors();

function renderStatColors() {
    document.querySelectorAll(".stat-value").forEach(stat => {
        if (stat.classList.contains("height")) return
        let statValue = stat.innerText

        switch (true) {
            case (statValue >= 90):
                stat.style.color = veryHighStat
                break
            case (statValue >= 80):
                stat.style.color = highStat
                break
            case (statValue >= 70):
                stat.style.color = normalStat
                break
            default:
                stat.style.color = lowStat
        }
    })
}

// ===== OVERALL CALCULATION =====

calculateOverall();

async function calculateOverall() {
    const player = {
        name: document.getElementById("name").value,
        position: document.getElementById("position").value,

        stats: {
            weakFootAccuracy: document.getElementById("weakFootAccuracy").value
        }
    };

    document.querySelectorAll(".stat").forEach(stat => {
        player.stats[stat.dataset.stat] = Number(stat.querySelector(".stat-value").innerText);
    });

    const response = await fetch("/Index?handler=CalculateOverall", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(player)
    });

    const result = await response.json();

    document.getElementById("overall").textContent = result.exactOverall;
}

// ===== GENERAL INPUTS =====

document.querySelector("#position").addEventListener("change", () => {
    calculateOverall();
});

document.querySelector("#weakFootAccuracy").addEventListener("change", () => {
    calculateOverall();
});


// ===== MINUS BUTTONS =====

document.querySelectorAll(".stat-minus-btn").forEach(btn => {

    if (!btn.nextElementSibling.querySelector(".stat-value").classList.contains("height")) {
        btn.addEventListener("click", (e) => {
            let statValue = Number(e.target.nextElementSibling.querySelector(".stat-value").innerText)

            if (statValue > 40) {
                e.target.nextElementSibling.querySelector(".stat-value").innerText--
                renderStatColors();
                calculateOverall();
            }
        });
    } else {
        btn.addEventListener("click", (e) => {
            let statValue = Number(e.target.nextElementSibling.querySelector(".stat-value").innerText)

            if (statValue > 150) {
                e.target.nextElementSibling.querySelector(".stat-value").innerText--
                renderStatColors();
                calculateOverall();
            }
        });
    }

});


// ===== PLUS BUTTONS =====

document.querySelectorAll(".stat-plus-btn").forEach(btn => {

    if (!btn.previousElementSibling.querySelector(".stat-value").classList.contains("height")) {
        btn.addEventListener("click", (e) => {
            let statValue = Number(e.target.previousElementSibling.querySelector(".stat-value").innerText);

            if (statValue < 99) {
                e.target.previousElementSibling.querySelector(".stat-value").innerText++;
                renderStatColors();
                calculateOverall();
            }
        });
    } else {
        btn.addEventListener("click", (e) => {
            let statValue = Number(e.target.previousElementSibling.querySelector(".stat-value").innerText);

            if (statValue < 210) {
                e.target.previousElementSibling.querySelector(".stat-value").innerText++;
                renderStatColors();
                calculateOverall();
            }
        });
    }

});

// ===== STAT INPUT =====

document.querySelectorAll(".stat-value").forEach(statValue => {

    statValue.addEventListener("click", (e) => {

        const input = e.target.previousElementSibling

        e.target.style.display = "none"
        input.style.display = "block"
        input.focus();
        input.select();
    })

})

document.querySelectorAll(".stat-input").forEach(statInput => {

    const statInputs = [...document.querySelectorAll(".stat-input")];

    statInput.addEventListener("keydown", (e) => {
        if (e.key === "Tab") {
            e.preventDefault();

            const index = statInputs.indexOf(e.target);

            if (index < statInputs.length - 1) {
                e.target.nextElementSibling.style.display = "block"
                e.target.style.display = "none"

                statInputs[index + 1].style.display = "block"
                statInputs[index + 1].focus();
                statInputs[index + 1].nextElementSibling.style.display = "none"
            } else {
                e.target.nextElementSibling.style.display = "block"
                e.target.style.display = "none"

                statInputs[0].style.display = "block"
                statInputs[0].focus();
                statInputs[0].nextElementSibling.style.display = "none"
            }
        }
    });

    statInput.addEventListener("keydown", (e) => {
        if (e.key === "Enter") {
            e.target.blur();
        }
    });

    statInput.addEventListener("blur", (e) => {

        const stat = e.target.nextElementSibling

        if (!stat.classList.contains("height")) {
            stat.innerText = clamp(Number(e.target.value), 40, 99)
        } else {
            stat.innerText = clamp(Number(e.target.value), 150, 210)
        }

        renderStatColors()
        calculateOverall()

        e.target.style.display = "none"
        stat.style.display = "block"
    })

})
