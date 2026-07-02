let overall = document.getElementById("overall")

calculateOverall();

async function calculateOverall() {
    const player = {
        name: document.getElementById("name").value,
        position: document.getElementById("position").value,

        stats: {
            weakFootAccuracy: document.getElementById("weakFootAccuracy").value
        }
    };

    document.querySelectorAll(".stat-slider").forEach(slider => {
        player.stats[slider.dataset.stat] = Number(slider.value);
    });

    const response = await fetch("/Index?handler=CalculateOverall", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(player)
    })

    const result = await response.json();

    document.getElementById("overall").textContent = result.overall;
}

document.querySelectorAll(".stat-slider").forEach(slider => {

    const value = slider.nextElementSibling;

    slider.addEventListener("input", () => {
        value.textContent = slider.value;
        calculateOverall();
    });

});

document.querySelector("#position").addEventListener("change", () => {
    calculateOverall();
})

document.querySelector("#weakFootAccuracy").addEventListener("change", () => {
    calculateOverall();
})