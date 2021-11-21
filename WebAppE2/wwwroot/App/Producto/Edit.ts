namespace ProductoEdit {

    var Entity = $("#AppEdit").data('entity');

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity
            },
            methods:
            {
                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando");
                        App.AxiosProvider.ProductoGuardar(this.Entity).then(data => {
                            Loading.close();

                            if (data.CodeError == 0) {
                                Toast.fire({ title: "Registro almacenado.", icon: "success" }).then(() => window.location.href = "Producto/Grid")
                            }
                            else {
                                Toast.fire({ title: data.MsgError, icon: "error" })
                            }
                        })
                    }
                    else {
                        Toast.fire({ title: "Campos obligatorios." });
                    }
                }
            },
            mounted() {
                CreateValidator(this.Formulario)
            }
        }
    );

    Formulario.$mount("#AppEdit")
}