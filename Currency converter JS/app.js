import { home } from "./controllers/home.js";
import { converterPost } from "./controllers/converter.js";

window.addEventListener("load", () => {
    const app = Sammy("#container", function () {
        this.use("Handlebars", "hbs");

        this.userData = {
            username: localStorage.getItem("username") || "",
            userId: localStorage.getItem("userId") || ""
        };

       
        this.get("/", home);
        this.get("index.html", home);
        this.get("#/home", home);

        console.log("start");
        this.post("#/converter", context => { converterPost.call(context); });

    });

    app.run();
});