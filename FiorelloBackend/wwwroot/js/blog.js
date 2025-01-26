"use strict"

let showMoreBtn = document.querySelector(".show-more");

let parentElem = document.querySelector(".parent-elem");

showMoreBtn.addEventListener("click", function () {
    let skip = parentElem.children.length;

    fetch(`https://localhost:7040/blog/showmore?skip=${skip}`)
        .then(response => response.text())
        .then(json => {
            this.previousElementSibling.innerHTML += json;
            skip = parentElem.children.length;
         
            if (skip == parseInt(this.getAttribute("data-count"))) {
                this.classList.add("d-none");
                return;
            }
        })
})

