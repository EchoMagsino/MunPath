document.addEventListener("DOMContentLoaded", function () {
    // Reveal triangles on scroll
    window.addEventListener("scroll", function () {
        const triangles = [
            document.getElementById("servicesTriangle"),
            document.getElementById("servicesTriangle2")
        ];
        triangles.forEach(t => {
            if (t && t.getBoundingClientRect().top < window.innerHeight - 100) {
                t.classList.add("visible");
            }
        });
    });

    // Toggle Content on Click
    function setupToggle(triangleId, contentId) {
        const triangle = document.getElementById(triangleId);
        const content = document.getElementById(contentId);
        if (triangle && content) {
            triangle.addEventListener("click", function () {
                // Remove Bootstrap's hidden class if it exists
                content.classList.remove("d-none");
                content.classList.toggle("show");
            });
        }
    }

    setupToggle("servicesTriangle", "servicesContent");
    setupToggle("servicesTriangle2", "servicesContent2");

    // Reveal wheel/tire cards when they enter the viewport (fix for background-images hidden by initial opacity)
    const wheelCards = document.querySelectorAll(".wheel-card");
    if (wheelCards.length) {
        // Use IntersectionObserver for performant scroll reveal
        const observer = new IntersectionObserver((entries, obs) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add("fade-in");
                    // Let the CSS animation handle opacity; stop observing once revealed
                    obs.unobserve(entry.target);
                }
            });
        }, {
            root: null,
            rootMargin: "0px 0px -10% 0px",
            threshold: 0.12
        });

        wheelCards.forEach(card => {
            observer.observe(card);
        });
    }
});