import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form"

const CreateNewGamePage = (props) => {


  const goBack = () => {
    navigator("/");
  };



  
  const {register, handleSubmit} = useForm()
  const onSubmit = (d) => 
    alert("Create game button was pushed. \ngameName: "+d.gameName + "\ngameRules: "+ d.gameRules +"\n" + JSON.stringify(d))
  

  let counter = 0;

  

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Create new Game</h1>
        </div>
      </div>
      <br></br>

      <br></br>

      <form onSubmit={handleSubmit(onSubmit)}>
        <div class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
        <label>
          Game name:
          <input class="appearance-none block w-100 bg-gray-200 text-gray-700 border border-red-500 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white" {...register("gameName")} />
        </label>
        
        <label>
          Input 2:
          <input class="appearance-none block w-100 bg-gray-200 text-gray-700 border border-red-500 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white" {...register("gameRules")} />
        </label>
        </div>
        <br></br>
        <button type="submit" className="btn">
          Create Game
        </button>
      </form>

      <button className="btn" onClick={goBack}>
        Go Back
      </button>
      <div className="divider" />
    </div>
  );
};

export default CreateNewGamePage;
