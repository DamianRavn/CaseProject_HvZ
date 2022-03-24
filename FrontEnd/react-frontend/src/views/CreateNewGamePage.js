import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form"

const CreateNewGamePage = () => {

  const navigator = useNavigate();

  const goBack = () => {
    navigator("/gamereg");
  };



  
  const {register, handleSubmit} = useForm()
  const onSubmit = (d) => 
    alert("Create game button was pushed. \ngameName: "+d.gameName + "\ngameRules: "+ d.gameRules +"\n" + JSON.stringify(d))
  

  let counter = 0;

  

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Create New Game Page</h1>
        </div>
      </div>
      <br></br>

      <br></br>

      <form onSubmit={handleSubmit(onSubmit)}>
        <label>
          Game name:
          <input {...register("gameName")} />
        </label>
        <label>
          Input 2:
          <input {...register("gameRules")} />
        </label>

        <p>Render: <span>{counter++}</span></p>
        {/* <input type="submit" > */}
          <button type="submit" className="btn">
            Create Game
          </button>
        {/* </input> */}

      </form>

      <button className="btn" onClick={goBack}>
        Go Back
      </button>
      <div className="divider" />
      
      


    </div>
  );
};

export default CreateNewGamePage;
