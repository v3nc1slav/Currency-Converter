import { home } from "./controllers/home.js";
import { moreOptions } from "./controllers/moreOptions.js";
import { services } from "./controllers/services.js";
import { contact } from "./controllers/contact.js";
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
        this.get("#/Home", home);

        this.get("#/MoreOptions", moreOptions);

        this.get("#/Services", services);

        this.get("#/Contact", contact);

        console.log("start");
        this.post("#/converter", context => { converterPost.call(context); });

    });

    app.run();
});
  